Partial Class AntennaTuner
	''' <summary> 
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing

	''' <summary> 
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(disposing As Boolean)
		If disposing AndAlso (components IsNot Nothing) Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

	#Region "Component Designer generated code"

	''' <summary> 
	''' Required method for Designer support - do not modify 
	''' the contents of this method with the code editor.
	''' </summary>
	Private Sub InitializeComponent()
		Me.tuneAntennasButton = New System.Windows.Forms.Button()
		Me.listBox1 = New System.Windows.Forms.ListBox()
		Me.restoreFactoryTuningsButtons = New System.Windows.Forms.Button()
		Me.measureReflegtedPowerButton = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		' 
		' tuneAntennasButton
		' 
		Me.tuneAntennasButton.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.tuneAntennasButton.Location = New System.Drawing.Point(6, 271)
		Me.tuneAntennasButton.Name = "tuneAntennasButton"
		Me.tuneAntennasButton.Size = New System.Drawing.Size(100, 23)
		Me.tuneAntennasButton.TabIndex = 0
		Me.tuneAntennasButton.Text = "Tune Antennas"
		AddHandler Me.tuneAntennasButton.Click, New System.EventHandler(AddressOf Me.tuneButton_Click)
		' 
		' listBox1
		' 
		Me.listBox1.Anchor = DirectCast((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.listBox1.Location = New System.Drawing.Point(6, 6)
		Me.listBox1.Name = "listBox1"
		Me.listBox1.Size = New System.Drawing.Size(378, 226)
		Me.listBox1.TabIndex = 1
		' 
		' restoreFactoryTuningsButtons
		' 
		Me.restoreFactoryTuningsButtons.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.restoreFactoryTuningsButtons.Location = New System.Drawing.Point(112, 271)
		Me.restoreFactoryTuningsButtons.Name = "restoreFactoryTuningsButtons"
		Me.restoreFactoryTuningsButtons.Size = New System.Drawing.Size(272, 23)
		Me.restoreFactoryTuningsButtons.TabIndex = 2
		Me.restoreFactoryTuningsButtons.Text = "Restore Tunings"
		AddHandler Me.restoreFactoryTuningsButtons.Click, New System.EventHandler(AddressOf Me.restoreFactoryTuningsButtons_Click)
		' 
		' measureReflegtedPowerButton
		' 
		Me.measureReflegtedPowerButton.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.measureReflegtedPowerButton.Location = New System.Drawing.Point(6, 242)
		Me.measureReflegtedPowerButton.Name = "measureReflegtedPowerButton"
		Me.measureReflegtedPowerButton.Size = New System.Drawing.Size(378, 23)
		Me.measureReflegtedPowerButton.TabIndex = 3
		Me.measureReflegtedPowerButton.Text = "Measure Reflected Powers"
		AddHandler Me.measureReflegtedPowerButton.Click, New System.EventHandler(AddressOf Me.measureReflegtedPowerButton_Click)
		' 
		' AntennaTuner
		' 
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
		Me.Controls.Add(Me.measureReflegtedPowerButton)
		Me.Controls.Add(Me.restoreFactoryTuningsButtons)
		Me.Controls.Add(Me.listBox1)
		Me.Controls.Add(Me.tuneAntennasButton)
		Me.Name = "AntennaTuner"
		Me.Size = New System.Drawing.Size(389, 297)
		Me.ResumeLayout(False)

	End Sub

	#End Region

	Private tuneAntennasButton As System.Windows.Forms.Button
	Private listBox1 As System.Windows.Forms.ListBox
	Private restoreFactoryTuningsButtons As System.Windows.Forms.Button
	Private measureReflegtedPowerButton As System.Windows.Forms.Button
End Class
