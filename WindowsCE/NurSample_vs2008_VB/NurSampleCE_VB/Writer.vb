Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Imports NurApiDotNet
'NurApi wrapper
Partial Public Class Writer
    Inherits UserControl
    Private hNur As NurApi = Nothing

    ''' <summary>
    ''' Initializes a new instance of the <see cref="Writer"/> class.
    ''' </summary>
    Public Sub New()
        InitializeComponent()
        Me.Enabled = False
        targetBankCB.SelectedIndex = NurApi.BANK_EPC
        memBankCB.SelectedIndex = NurApi.BANK_TID
        securityCB.SelectedIndex = 0
        secLockStateCB.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' Sets the NurApi.
    ''' </summary>
    ''' <param name="hNur">The handle of NurApi.</param>
    Public Sub SetNurApi(ByVal hNur As NurApi)
        Try
            Me.hNur = hNur

            ' Set event handlers for NurApi
            AddHandler hNur.DisconnectedEvent, New EventHandler(Of NurApi.NurEventArgs)(AddressOf hNur_DisconnectedEvent)
            AddHandler hNur.ConnectedEvent, New EventHandler(Of NurApi.NurEventArgs)(AddressOf hNur_ConnectedEvent)

            ' Update the status of the connection
            If hNur.IsConnected() Then
                hNur_ConnectedEvent(hNur, Nothing)
            Else
                hNur_DisconnectedEvent(hNur, Nothing)
            End If
        Catch ex As NurApiException
            MessageBox.Show(ex.ToString(), Program.appName)
        End Try
    End Sub

    ''' <summary>
    ''' Handles the DisconnectedEvent event of the NUR module.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="NurApi.NurEventArgs" /> instance containing the event data.</param>
    Private Sub hNur_DisconnectedEvent(ByVal sender As Object, ByVal e As NurApi.NurEventArgs)
        Dim hNur As NurApi = TryCast(sender, NurApi)
        Me.Enabled = False
    End Sub

    ''' <summary>
    ''' Handles the ConnectedEvent event of the NUR module.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="NurApi.NurEventArgs" /> instance containing the event data.</param>
    Private Sub hNur_ConnectedEvent(ByVal sender As Object, ByVal e As NurApi.NurEventArgs)
        Dim hNur As NurApi = TryCast(sender, NurApi)
        Me.Enabled = True
    End Sub

    ''' <summary>
    ''' Handles the Click event of the refreshBtn control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub refreshBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Clear Tag List
        writeTagListView.ClearTagList()
        ' Clear previously inventoried tags from memory
        hNur.ClearTags()
        ' Perform simple inventory
        For i As Integer = 0 To 2
            hNur.SimpleInventory()
        Next
        ' Fetch tags from module, including tag meta
        Dim inventoriedTags As NurApi.TagStorage = hNur.FetchTags(True)
        ' Update Tag List
        writeTagListView.UpdateTagList(inventoriedTags)
    End Sub

    ''' <summary>
    ''' Handles the SelectedTagChanged event of the writeTagListView control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub writeTagListView_SelectedTagChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim selectedTag As NurApi.Tag = writeTagListView.SelectedTag
        If selectedTag IsNot Nothing Then
            SetTargetTag(NurApi.BANK_EPC, 32, selectedTag.epc)
        End If
    End Sub

    ''' <summary>
    ''' Handles the Click event of the pickUpButton control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub pickUpButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim usedTxLevel As Integer
            Dim strongestTag As NurApi.Tag = Nothing
            Dim nurbeOfTags As Integer = NurUtils.SearchNearestTag(hNur, True, strongestTag, usedTxLevel)
            If nurbeOfTags = 1 Then
                SetTargetTag(NurApi.BANK_EPC, 32, strongestTag.epc)
            End If
        Catch ex As NurApiException
            MessageBox.Show(ex.Message, Program.appName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    ''' <summary>
    ''' Sets the target tag.
    ''' </summary>
    ''' <param name="bank">The bank.</param>
    ''' <param name="start">The start.</param>
    ''' <param name="mask">The mask.</param>
    Private Sub SetTargetTag(ByVal bank As Byte, ByVal start As UInteger, ByVal mask As Byte())
        If mask Is Nothing Then
            mask = New Byte(-1) {}
        End If

        ' Fill Target
        targetBankCB.SelectedIndex = NurApi.BANK_EPC
        targetStartUD.Value = 32
        targetMaskTextBox.Text = NurApi.BinToHexString(mask)
        targetLengthUD.Value = mask.Length * 8
        ' Fill EPC
        newEpcTextBox.Text = targetMaskTextBox.Text

        UpdateTargetTagControls()
    End Sub

    ''' <summary>
    ''' Updates the target tag controls.
    ''' </summary>
    Private Sub UpdateTargetTagControls()
        Dim target As String
        If targetLengthUD.Value > 0 Then
            target = String.Format("{0}[{1}/{2}]{3}", targetBankCB.Items(targetBankCB.SelectedIndex).ToString(), targetStartUD.Value, targetLengthUD.Value, targetMaskTextBox.Text)
        Else
            target = "Target is not set!"
        End If

        targetEpcLabel.Text = target
        targetMemLabel.Text = target
        targetAccessLabel.Text = target
    End Sub

    ''' <summary>
    ''' Handles the SelectedIndexChanged event of the tabControl1 control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub tabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        If writeTagListView.FocusedItem IsNot Nothing Then
            writeTagListView.FocusedItem.Selected = False
        End If
    End Sub

    ''' <summary>
    ''' Handles the Click event of the writeNewEpcBtn control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub writeNewEpcBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim message As String = "New EPC written successfully!"
        Dim startTick As Integer = System.Environment.TickCount
        Dim icon As MessageBoxIcon = MessageBoxIcon.None
        Try
            ' Write new EPC and set correct length
            Dim passwd As UInteger = UInteger.Parse(passwdTextBox.Text, System.Globalization.NumberStyles.HexNumber)
            Dim secured As Boolean = usePasswdCheckBox.Checked
            Dim sBank As Byte = CByte(targetBankCB.SelectedIndex)
            Dim sAddress As UInteger = CUInt(targetStartUD.Value)
            Dim sMaskBitLength As Integer = CInt(targetLengthUD.Value)
            Dim sMask As Byte() = NurApi.HexStringToBin(targetMaskTextBox.Text)
            Dim epcBuffer As Byte() = NurApi.HexStringToBin(newEpcTextBox.Text)
            hNur.WriteEPC(passwd, secured, sBank, sAddress, sMaskBitLength, sMask, _
             epcBuffer)
        Catch ex As NurApiException
            message = NurApiErrors.ErrorCodeToString(ex.[error])
            icon = MessageBoxIcon.Hand
        Catch ex As Exception
            message = ex.Message
            icon = MessageBoxIcon.Hand
        End Try
        ' Show result
        Dim title As String = String.Format("{0} {1} ms", Program.appName, System.Environment.TickCount - startTick)
        MessageBox.Show(message, title, MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1)

        ' Refresh list
        refreshBtn_Click(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the readMemButton control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub readMemButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim message As String
        Dim startTick As Integer = System.Environment.TickCount
        Dim icon As MessageBoxIcon = MessageBoxIcon.None
        Try
            ' Read memory from Tag
            Dim passwd As UInteger = UInteger.Parse(passwdTextBox.Text, System.Globalization.NumberStyles.HexNumber)
            Dim secured As Boolean = usePasswdCheckBox.Checked
            Dim sBank As Byte = CByte(targetBankCB.SelectedIndex)
            Dim sAddress As UInteger = CUInt(targetStartUD.Value)
            Dim sMaskBitLength As Integer = CInt(targetLengthUD.Value)
            Dim sMask As Byte() = NurApi.HexStringToBin(targetMaskTextBox.Text)
            Dim rdBank As Byte = CByte(memBankCB.SelectedIndex)
            Dim rdAddress As UInteger = CUInt(memStartUD.Value)
            Dim rdByteCount As Byte = CByte(memLengthUD.Value)
            Dim data As Byte()
            If memUseReadBlockCheckBox.Checked Then
                data = NurSample.NurRead.ReadBank(hNur, passwd, secured, sBank, sAddress, sMaskBitLength, _
     sMask, rdBank, rdAddress, rdByteCount)
            Else
                data = hNur.ReadSingulatedTag(passwd, secured, sBank, sAddress, sMaskBitLength, sMask, _
                 rdBank, rdAddress, rdByteCount)
            End If
            memTextBox.Text = NurApi.BinToHexString(data)
            message = String.Format("{0} bytes read successfully " & vbLf & "in {1} ms.", data.Length, System.Environment.TickCount - startTick)
        Catch ex As NurApiException
            message = NurApiErrors.ErrorCodeToString(ex.[error])
            icon = MessageBoxIcon.Hand
        Catch ex As Exception
            message = ex.Message
            icon = MessageBoxIcon.Hand
        End Try
        ' Show result
        Dim title As String = String.Format("{0} {1} ms", Program.appName, System.Environment.TickCount - startTick)
        MessageBox.Show(message, title, MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the writeMemButton control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    ''' <exception cref="System.Exception">
    ''' mission impossible
    ''' or
    ''' Invalid parameter
    ''' </exception>
    Private Sub writeMemButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim message As String = "Memory written successfully!"
        Dim startTick As Integer = System.Environment.TickCount
        Dim icon As MessageBoxIcon = MessageBoxIcon.None
        Try
            ' Write Tag memory
            Dim passwd As UInteger = UInteger.Parse(passwdTextBox.Text, System.Globalization.NumberStyles.HexNumber)
            Dim secured As Boolean = usePasswdCheckBox.Checked
            Dim sBank As Byte = CByte(targetBankCB.SelectedIndex)
            Dim sAddress As UInteger = CUInt(targetStartUD.Value)
            Dim sMaskBitLength As Integer = CInt(targetLengthUD.Value)
            Dim sMask As Byte() = NurApi.HexStringToBin(targetMaskTextBox.Text)
            Dim wrBank As Byte = CType(memBankCB.SelectedIndex, [Byte])
            Dim wrAddress As UInteger = CUInt(memStartUD.Value)
            Dim wrBuffer As Byte() = NurApi.HexStringToBin(memTextBox.Text)
            hNur.WriteSingulatedTag(passwd, secured, sBank, sAddress, sMaskBitLength, sMask, _
             wrBank, wrAddress, wrBuffer)
        Catch ex As NurApiException
            message = NurApiErrors.ErrorCodeToString(ex.[error])
            icon = MessageBoxIcon.Hand
        Catch ex As Exception
            message = ex.Message
            icon = MessageBoxIcon.Hand
        End Try
        ' Show result
        Dim title As String = String.Format("{0} {1} ms", Program.appName, System.Environment.TickCount - startTick)
        MessageBox.Show(message, title, MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the setLockStateButton control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub setLockStateButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim message As String = "Lock state(s) set successfully!"
        Dim startTick As Integer = System.Environment.TickCount
        Dim icon As MessageBoxIcon = MessageBoxIcon.None
        Try
            ' Write Tag memory
            Dim passwd As UInteger = UInteger.Parse(passwdTextBox.Text, System.Globalization.NumberStyles.HexNumber)
            Dim secured As Boolean = usePasswdCheckBox.Checked
            Dim sBank As Byte = CByte(targetBankCB.SelectedIndex)
            Dim sAddress As UInteger = CUInt(targetStartUD.Value)
            Dim sMaskBitLength As Integer = CInt(targetLengthUD.Value)
            Dim sMask As Byte() = NurApi.HexStringToBin(targetMaskTextBox.Text)
            Dim memoryMask As UInteger = 0
            If lockUserCheckBox.Checked Then
                memoryMask = memoryMask Or NurApi.LOCK_USERMEM
            End If
            If lockTicCheckBox.Checked Then
                memoryMask = memoryMask Or NurApi.LOCK_TIDMEM
            End If
            If lockEpcCheckBox.Checked Then
                memoryMask = memoryMask Or NurApi.LOCK_EPCMEM
            End If
            If lockAccessCheckBox.Checked Then
                memoryMask = memoryMask Or NurApi.LOCK_ACCESSPWD
            End If
            If lockKillCheckBox.Checked Then
                memoryMask = memoryMask Or NurApi.LOCK_KILLPWD
            End If
            Dim action As UInteger = CUInt(secLockStateCB.SelectedIndex)
            hNur.SetLock(passwd, sBank, sAddress, sMaskBitLength, sMask, memoryMask, _
             action)
        Catch ex As NurApiException
            message = NurApiErrors.ErrorCodeToString(ex.[error])
            icon = MessageBoxIcon.Hand
        Catch ex As Exception
            message = ex.Message
            icon = MessageBoxIcon.Hand
        End Try
        ' Show result
        Dim title As String = String.Format("{0} {1} ms", Program.appName, System.Environment.TickCount - startTick)
        MessageBox.Show(message, title, MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the readPasswordButton control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub readPasswordButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim message As String = "Password read successfully!"
        Dim startTick As Integer = System.Environment.TickCount
        Dim icon As MessageBoxIcon = MessageBoxIcon.None
        Try
            ' Read memory from Tag
            Dim passwd As UInteger = UInteger.Parse(passwdTextBox.Text, System.Globalization.NumberStyles.HexNumber)
            Dim secured As Boolean = usePasswdCheckBox.Checked
            Dim sBank As Byte = CByte(targetBankCB.SelectedIndex)
            Dim sAddress As UInteger = CUInt(targetStartUD.Value)
            Dim sMaskBitLength As Integer = CInt(targetLengthUD.Value)
            Dim sMask As Byte() = NurApi.HexStringToBin(targetMaskTextBox.Text)
            Dim password As UInteger
            Select Case securityCB.SelectedIndex
                Case 0
                    ' Kill
                    password = hNur.GetKillPassword(passwd, secured, sBank, sAddress, sMaskBitLength, sMask)
                    Exit Select
                Case 1
                    ' Access
                    password = hNur.GetAccessPassword(passwd, secured, sBank, sAddress, sMaskBitLength, sMask)
                    Exit Select
                Case Else
                    Throw New Exception("Invalid parameter")
            End Select
            If BitConverter.IsLittleEndian Then
                password = ReverseBytes(password)
            End If
            Dim pwdBytes As Byte() = BitConverter.GetBytes(password)
            secPasswdTextBox.Text = NurApi.BinToHexString(pwdBytes)
        Catch ex As NurApiException
            message = NurApiErrors.ErrorCodeToString(ex.[error])
            icon = MessageBoxIcon.Hand
        Catch ex As Exception
            message = ex.Message
            icon = MessageBoxIcon.Hand
        End Try
        ' Show result
        Dim title As String = String.Format("{0} {1} ms", Program.appName, System.Environment.TickCount - startTick)
        MessageBox.Show(message, title, MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1)
    End Sub

    ''' <summary>
    ''' reverse byte order (32-bit)
    ''' </summary>
    ''' <param name="value">The value.</param>
    ''' <returns></returns>
    Public Shared Function ReverseBytes(ByVal value As UInt32) As UInt32
        Return (value And &HFFUI) << 24 Or (value And &HFF00UI) << 8 Or (value And &HFF0000UI) >> 8 Or (value And &HFF000000UI) >> 24
    End Function

    ''' <summary>
    ''' Handles the Click event of the writePasswordButton control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub writePasswordButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim message As String = "Password written successfully!"
        Dim startTick As Integer = System.Environment.TickCount
        Dim icon As MessageBoxIcon = MessageBoxIcon.None
        Try
            ' Write password
            Dim passwd As UInteger = UInteger.Parse(passwdTextBox.Text, System.Globalization.NumberStyles.HexNumber)
            Dim secured As Boolean = usePasswdCheckBox.Checked
            Dim sBank As Byte = CByte(targetBankCB.SelectedIndex)
            Dim sAddress As UInteger = CUInt(targetStartUD.Value)
            Dim sMaskBitLength As Integer = CInt(targetLengthUD.Value)
            Dim sMask As Byte() = NurApi.HexStringToBin(targetMaskTextBox.Text)
            Dim newPasswd As UInteger = UInteger.Parse(secPasswdTextBox.Text, System.Globalization.NumberStyles.HexNumber)


            Select Case securityCB.SelectedIndex
                Case 0
                    ' Kill
                    hNur.SetKillPassword(passwd, secured, sBank, sAddress, sMaskBitLength, sMask, _
                     newPasswd)
                    Exit Select
                Case 1
                    ' Access
                    hNur.SetAccessPassword(passwd, secured, sBank, sAddress, sMaskBitLength, sMask, _
                     newPasswd)
                    Exit Select
                Case Else
                    Throw New Exception("Invalid parameter")
            End Select
        Catch ex As NurApiException
            message = NurApiErrors.ErrorCodeToString(ex.[error])
            icon = MessageBoxIcon.Hand
        Catch ex As Exception
            message = ex.Message
            icon = MessageBoxIcon.Hand
        End Try
        ' Show result
        Dim title As String = String.Format("{0} {1} ms", Program.appName, System.Environment.TickCount - startTick)
        MessageBox.Show(message, title, MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the killButton control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub killButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim message As String = "Tag killed successfully!"
        Dim startTick As Integer = System.Environment.TickCount
        Dim icon As MessageBoxIcon = MessageBoxIcon.None
        Try
            ' Kill Tag
            Dim passwd As UInteger = UInteger.Parse(secPasswdTextBox.Text, System.Globalization.NumberStyles.HexNumber)
            Dim sBank As Byte = CByte(targetBankCB.SelectedIndex)
            Dim sAddress As UInteger = CUInt(targetStartUD.Value)
            Dim sMaskBitLength As Integer = CInt(targetLengthUD.Value)
            Dim sMask As Byte() = NurApi.HexStringToBin(targetMaskTextBox.Text)
            Dim newPasswd As UInteger = UInteger.Parse(secPasswdTextBox.Text, System.Globalization.NumberStyles.HexNumber)


            hNur.KillTag(passwd, sBank, sAddress, sMaskBitLength, sMask)
        Catch ex As NurApiException
            message = NurApiErrors.ErrorCodeToString(ex.[error])
            icon = MessageBoxIcon.Hand
        Catch ex As Exception
            message = ex.Message
            icon = MessageBoxIcon.Hand
        End Try
        ' Show result
        Dim title As String = String.Format("{0} {1} ms", Program.appName, System.Environment.TickCount - startTick)
        MessageBox.Show(message, title, MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1)
    End Sub

    ''' <summary>
    ''' Handles the CheckStateChanged event of the memUseReadBlockCheckBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub memUseReadBlockCheckBox_CheckStateChanged(ByVal sender As Object, ByVal e As EventArgs)
        If memUseReadBlockCheckBox.Checked Then
            memLengthUD.Value = 0
        End If
    End Sub
End Class
