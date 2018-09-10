/*=======================================================================================

    Smart ReadBank method that reads the entire memory till the end or a fixed part
    of it.

=======================================================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

using NurApiDotNet;

namespace NurSample
{
    static class NurRead
    {
        const int RETRIES = 4;
        static bool chancelReading = false;

        readonly static int[] generalPurposeBSS = new int[] { 8, 12, 4, 2 };    // General Purpose Bank Size Suggestion
        static Dictionary<byte[], int[]> bankSizeDictionary = new Dictionary<byte[], int[]>(new ByteArrayComparer());

        static NurRead()
        {
            // Add Bank Size Suggestion table to the dictionary
            bankSizeDictionary.Add(new byte[] { 0xE2, 0x00, 0x10, 0x93 }, new int[] { 14, 16,  4,    2 });
            bankSizeDictionary.Add(new byte[] { 0xE2, 0x00, 0x34, 0x12 }, new int[] {  8, 16, 24,   64 });
            bankSizeDictionary.Add(new byte[] { 0xE2, 0x00, 0x60, 0x04 }, new int[] {  8, 34,  8,   64 });
            bankSizeDictionary.Add(new byte[] { 0xE2, 0x80, 0x11, 0x05 }, new int[] { 14, 20, 24,   64 });
            bankSizeDictionary.Add(new byte[] { 0xE2, 0x80, 0x11, 0x60 }, new int[] {  8, 16, 12,    2 });
            bankSizeDictionary.Add(new byte[] { 0xE2, 0x00, 0x68, 0x05 }, new int[] {  8, 20,  8,    2 });
            bankSizeDictionary.Add(new byte[] { 0xE2, 0x00, 0x68, 0x06 }, new int[] {  8, 20,  8,    2 });
            bankSizeDictionary.Add(new byte[] { 0xE2, 0x00, 0x68, 0x0a }, new int[] {  8, 36, 26,   64 });
            bankSizeDictionary.Add(new byte[] { 0xE2, 0x80, 0x68, 0x10 }, new int[] {  8, 20, 12,    0 });
            bankSizeDictionary.Add(new byte[] { 0xE2, 0x01, 0x00, 0x61 }, new int[] {  8, 70, 32, 3424 });
        }

        public class ByteArrayComparer : IEqualityComparer<byte[]>
        {
            public bool Equals(byte[] left, byte[] right)
            {
                if (left == null || right == null)
                {
                    return left == right;
                }
                if (left.Length != right.Length)
                {
                    return false;
                }
                for (int i = 0; i < left.Length; i++)
                {
                    if (left[i] != right[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            public int GetHashCode(byte[] key)
            {
                if (key == null)
                    throw new ArgumentNullException("key");
                int sum = 0;
                foreach (byte cur in key)
                {
                    sum += cur;
                }
                return sum;
            }
        }

        /// <summary>
        /// Target Cache compares the singulation data for the previous one
        /// and resturns the tag identifier (E2+MDID+TMN) is exist.
        /// </summary>
        public class TargetCache
        {
            static uint _passwd = 0;
            static bool _secured = false;
            static byte _sBank = 0;
            static uint _sAddress = 0;
            static int _sMaskBitLength = 0;
            static byte[] _sMask = null;
            static byte[] _tagIdentifier = null;
            static ByteArrayComparer bac = new ByteArrayComparer();
            /// <summary>
            /// Sets the tag identifier (E2+MDID+TMN) for cache.
            /// </summary>
            /// <param name="tagIdentifier">The tag identifier.</param>
            /// <param name="passwd">The access password.</param>
            /// <param name="secured">Use password if set to <c>true</c>.</param>
            /// <param name="sBank">The singulation bank.</param>
            /// <param name="sAddress">The singulation address (bits).</param>
            /// <param name="sMaskBitLength">Length of the singulation mask (bits).</param>
            /// <param name="sMask">The singulation mask.</param>
            static public void SetTagIdentifier(byte[] tagIdentifier, uint passwd, bool secured, byte sBank, uint sAddress, int sMaskBitLength, byte[] sMask)
            {
                _passwd = passwd;
                _secured = secured;
                _sBank = sBank;
                _sAddress = sAddress;
                _sMaskBitLength = sMaskBitLength;
                _sMask = sMask;
                _tagIdentifier = tagIdentifier;
            }
            /// <summary>
            /// Gets the tag identifier (E2+MDID+TMN) from the chache if found.
            /// </summary>
            /// <param name="passwd">The access password.</param>
            /// <param name="secured">Use password if set to <c>true</c>.</param>
            /// <param name="sBank">The singulation bank.</param>
            /// <param name="sAddress">The singulation address (bits).</param>
            /// <param name="sMaskBitLength">Length of the singulation mask (bits).</param>
            /// <param name="sMask">The singulation mask.</param>
            /// <returns></returns>
            static public byte[] GetTagIdentifier(uint passwd, bool secured, byte sBank, uint sAddress, int sMaskBitLength, byte[] sMask)
            {
                if (_passwd != passwd)
                    return null;
                if (_secured != secured)
                    return null;
                if (_sBank != sBank)
                    return null;
                if (_sAddress != sAddress)
                    return null;
                if (_sMaskBitLength != sMaskBitLength)
                    return null;
                if (!bac.Equals(_sMask, sMask))
                    return null;
                return _tagIdentifier;
            }
        }

        /// <summary>
        /// Reads the part of the memory or whole bank.
        /// </summary>
        /// <param name="hNur">The hNur handler.</param>
        /// <param name="passwd">The access password.</param>
        /// <param name="secured">Use password if set to <c>true</c>.</param>
        /// <param name="sBank">The singulation bank.</param>
        /// <param name="sAddress">The singulation address (bits).</param>
        /// <param name="sMaskBitLength">Length of the singulation mask (bits).</param>
        /// <param name="sMask">The singulation mask.</param>
        /// <param name="rdBank">The read bank.</param>
        /// <param name="rdAddress">The read address (words).</param>
        /// <param name="rdByteCount">The rd byte count (bytes).</param>
        /// <returns></returns>
        static public byte[] ReadBank(NurApi hNur, uint passwd, bool secured, byte sBank, uint sAddress, int sMaskBitLength, byte[] sMask, byte rdBank, uint rdAddress, int rdByteCount)
        {
            int t1 = System.Environment.TickCount;
            int rdNumOfBytes = 0;
            int rdMaxNumOfBytes = 100;
            int bankSizeSuggestion = 0;
            int outOfMemory = Int32.MaxValue;
            byte[] tagIdentifier = null;

            if (rdByteCount == 0)
            {
                // rdByteCount is zero meaning read till the end
                // Get Tag Identifier
                if (sBank != NurApi.BANK_TID || sAddress != 0 || sMaskBitLength < 32)
                {
                    // Check if we already know the TagIdentifier
                    tagIdentifier = TargetCache.GetTagIdentifier(passwd, secured, sBank, sAddress, sMaskBitLength, sMask);
                    if (tagIdentifier == null)
                    {
                        // Unknown TAG type. Get E2, mask designer identifier (MDID)
                        // and Tag model number (TMN) from TID memory.
                        for (int retryTidCnt = 0; retryTidCnt < RETRIES; retryTidCnt++)
                        {
                            try
                            {
                                tagIdentifier = hNur.ReadSingulatedTag(passwd, secured, sBank, sAddress, sMaskBitLength, sMask, NurApi.BANK_TID, 0, 32 / 8);
                                if (new ByteArrayComparer().Equals(tagIdentifier, new byte[] { 0, 0, 0, 0 }))
                                {
                                    // Fix the alignment bug seen in the Fujitsu's tag
                                    tagIdentifier = hNur.ReadSingulatedTag(passwd, secured, sBank, sAddress, sMaskBitLength, sMask, NurApi.BANK_TID, 2, 32 / 8);
                                }
                                // Store the read TagIdentifier to the TargetCache for future use.
                                TargetCache.SetTagIdentifier(tagIdentifier, passwd, secured, sBank, sAddress, sMaskBitLength, sMask);
                                break;
                            }
                            catch (NurApiException)
                            {
                            }
                        }
                    }
                }
                else
                {
                    // We already know the Tag Identifier
                    // Just copy it.
                    tagIdentifier = new byte[32 / 8];
                    Array.Copy(sMask, tagIdentifier, 32 / 8);
                }

                // Get bank size suggestion 
                int[] bankSize;
                if (tagIdentifier != null && bankSizeDictionary.TryGetValue(tagIdentifier, out bankSize))
                {
                    // Get known bank size suggestion 
                    bankSizeSuggestion = bankSize[rdBank];
                }
                else
                {
                    // Get general purpose bank size suggestion
                    bankSizeSuggestion = generalPurposeBSS[rdBank];
                }
                rdNumOfBytes = (int)bankSizeSuggestion;
            }
            else
            {
                // Read fixed number of bytes
                rdNumOfBytes = rdByteCount;
            }

            NurApiException tempException = null;
            List<byte> byteList = new List<byte>();

            // Read Tag
            int retryCnt = 0;
            chancelReading = false;
            do
            {
                // Chancel reading if requested
                if (chancelReading)
                    break;

                // Are we reached the fixed number of bytes (rdByteCount > 0)
                if (rdByteCount > 0 &&
                    byteList.Count >= rdByteCount)
                    break;

                // First check the error / retry counter
                if (retryCnt > RETRIES)
                    break;

                // Calculate some usefull values
                int startAddress = (int)rdAddress * 2;
                int suggestedBytesLeft = bankSizeSuggestion - startAddress;
                int outOfMemoryLeft = outOfMemory - startAddress;
                int lastReadAddress = rdNumOfBytes + startAddress;

                // rdNumOfBytes = suggested size
                if (suggestedBytesLeft < rdNumOfBytes && startAddress < bankSizeSuggestion)
                    rdNumOfBytes = (int)suggestedBytesLeft;

                // Make sure that the rdNumOfBytes < than latest outOfMemory
                if (outOfMemoryLeft - 4 <= rdNumOfBytes)
                    rdNumOfBytes = (int)outOfMemoryLeft - 4;

                // Make sure that the rdNumOfBytes is not bigget than latest known MaxNumOfBytes
                if (rdNumOfBytes > rdMaxNumOfBytes)
                    rdNumOfBytes = rdMaxNumOfBytes;

                // Last but not least, make sure that we read at least one word
                if (rdNumOfBytes < 2)
                    rdNumOfBytes = 2;

                // Make sure thet we don't read more than requested rdByteCount
                if (rdByteCount > 0 &&
                    byteList.Count + rdNumOfBytes > rdByteCount)
                    rdNumOfBytes = rdByteCount - byteList.Count;

                try
                {
                    // Read the content of the memory bank
                    byte[] bytes = null;
                    //RFID_Demo.Debug.WriteToFile(string.Format("Read addr:{0}, Bytes:{1}", rdAddress*2, rdNumOfBytes));
                    bytes = hNur.ReadSingulatedTag(passwd, secured, sBank, sAddress, sMaskBitLength, sMask, rdBank, rdAddress, rdNumOfBytes);
                    byteList.AddRange(bytes);
                    tempException = null;
                    retryCnt = 0;
                }
                catch (NurApiException ex)
                {
                    //RFID_Demo.Debug.WriteToFile(string.Format("NurApiException {0}: {1}", ex.error, NurApiErrors.ErrorCodeToString(ex.error)));
                    tempException = ex;
                    if (ex.error == NurApiErrors.NUR_ERROR_G2_TAG_MEM_OVERRUN)
                    {
                        // Out of memory!!!
                        retryCnt = 0;
                        outOfMemory = ((int)rdAddress * 2) + rdNumOfBytes;
                        if (rdNumOfBytes > 2)
                        {
                            // Read rest of mem by word by word.
                            rdNumOfBytes = 2;
                            continue;
                        }
                        // The end of memory reached. Stop reading and clear the exception. 
                        tempException = null;
                        break;
                    }
                    else if (ex.error == NurApiErrors.NUR_ERROR_G2_READ)
                    {
                        // This may occur if we try to read too much or the connection is too weak
                        if (rdNumOfBytes == rdMaxNumOfBytes)
                            rdMaxNumOfBytes -= 4;
                        continue;
                    }

                    // Some other error occurred
                    System.Diagnostics.Debug.WriteLine(string.Format("Error {0}, {2}: {1}", ex.error, NurApiErrors.ErrorCodeToString(ex.error), rdNumOfBytes));
                    retryCnt++;
                    continue;
                }

                // Move word address to forward.
                rdAddress += (uint)rdNumOfBytes / 2;

                // If the suggested end of the memory is reached try to read only the next word
                if (bankSizeSuggestion == rdAddress * 2)
                    rdNumOfBytes = 2;

                // Try increase the reading speed if there is mode memory than suggested.
                if (bankSizeSuggestion < rdAddress * 2)
                    rdNumOfBytes *= 2;
            } while (true);

            // throw exception if exist 
            if (tempException != null)
                throw tempException;

            if (rdByteCount == 0 && tagIdentifier != null)
            {
                // Update the bank size suggestion 
                // Get bank size suggestion 
                if (bankSizeDictionary.ContainsKey(tagIdentifier))
                {
                    bankSizeDictionary[tagIdentifier][rdBank] = byteList.Count;
                }
                else
                {
                    int[] newBSS = new int[generalPurposeBSS.Length];
                    generalPurposeBSS.CopyTo(newBSS, 0);
                    newBSS[rdBank] = byteList.Count;
                    bankSizeDictionary.Add(tagIdentifier, newBSS);
                }
            }
            System.Diagnostics.Debug.WriteLine(System.Environment.TickCount - t1);
            return byteList.ToArray();
        }

        /// <summary>
        /// Chancels the reading.
        /// </summary>
        static public void ChancelReading()
        {
            chancelReading = true;
        }
    }
}
