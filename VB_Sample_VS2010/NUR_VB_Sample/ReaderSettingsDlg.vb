Imports System.Windows.Forms
Imports NurApiDotNet

Public Class ReaderSettingsDlg

    Public nurSettings As NurApi.ModuleSetup

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        ReadSettingsFromComboBox(nurSettings)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ReadSettingsFromComboBox(ByRef settingsStruct As NurApi.ModuleSetup)
        'Copy settings from Comboboxes to NurSettings struct
        'Set values to NUR_SETTINGS struct
        settingsStruct.regionId = ComboRegion.SelectedIndex
        settingsStruct.txLevel = ComboTxLevel.SelectedIndex
        settingsStruct.linkFreq = Val(ComboLinkFrequency.Text)
        settingsStruct.rxDecoding = ComboRxDecoding.SelectedIndex
        settingsStruct.txModulation = ComboTxModulation.SelectedIndex

        settingsStruct.inventoryQ = ComboQ.SelectedIndex
        settingsStruct.inventoryRounds = ComboRounds.SelectedIndex
        settingsStruct.inventorySession = ComboSession.SelectedIndex

        'settingsStruct.logFilePath = LabelLogPath.Text
        'settingsStruct.enableLogToFile = CheckLogToFile.Checked

    End Sub
    Private Sub LoadSettingsToCombobox(ByRef settingsStruct As NurApi.ModuleSetup)
        'Copy settings from Comboboxes to NurSettings struct
        'Set values to NUR_SETTINGS struct
        ComboRegion.SelectedIndex = settingsStruct.regionId
        ComboTxLevel.SelectedIndex = settingsStruct.txLevel

        If settingsStruct.linkFreq = 160000 Then
            ComboLinkFrequency.SelectedIndex = 0
        ElseIf settingsStruct.linkFreq = 256000 Then
            ComboLinkFrequency.SelectedIndex = 1
        ElseIf settingsStruct.linkFreq = 320000 Then
            ComboLinkFrequency.SelectedIndex = 2
        End If

        ComboRxDecoding.SelectedIndex = settingsStruct.rxDecoding
        ComboTxModulation.SelectedIndex = settingsStruct.txModulation

        ComboQ.SelectedIndex = settingsStruct.inventoryQ
        ComboRounds.SelectedIndex = settingsStruct.inventoryRounds
        ComboSession.SelectedIndex = settingsStruct.inventorySession

        'LabelLogPath.Text = settingsStruct.logFilePath
        'CheckLogToFile.Checked = settingsStruct.enableLogToFile

    End Sub


    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Private Sub ReaderSettingsDlg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        nurSettings = Form1.hNur.GetModuleSetup() 'Get current module settings from reader
        LoadSettingsToCombobox(nurSettings) 'Update Controls
    End Sub

    Private Sub ButtonLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLoad.Click

        Dim dlg As New OpenFileDialog

        dlg.Filter() = "RFID Settings files (*)|*.nur"
        dlg.Title() = "Choose RFID Settings file"
        If (dlg.ShowDialog() = Windows.Forms.DialogResult.OK) Then

            Form1.hNur.LoadSetupFile(dlg.FileName)
            nurSettings = Form1.hNur.GetModuleSetup() 'Get current module settings from reader
            LoadSettingsToCombobox(nurSettings) 'Update Controls
            'Me.Text = "RFID settings (" & dlg.FileName & ")"
        End If

    End Sub

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        Dim dlg As New SaveFileDialog

        dlg.Filter() = "RFID Settings files (*)|*.nur"
        dlg.Title() = "Save RFID Settings file"
        If (dlg.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            ReadSettingsFromComboBox(nurSettings)
            Form1.hNur.SaveSetupFile(dlg.FileName)

        End If
    End Sub
End Class
