<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.BtnLoadFile = New System.Windows.Forms.Button()
        Me.BtnForceLoad = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnForceClose = New System.Windows.Forms.Button()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.BtnStatus = New System.Windows.Forms.Button()
        Me.BtnPing = New System.Windows.Forms.Button()
        Me.TxtFileName = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabMain = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.DataGridMain = New System.Windows.Forms.DataGridView()
        Me.PartNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RunPrev = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ProgressBarBOM = New System.Windows.Forms.ProgressBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblLBStatus = New System.Windows.Forms.Label()
        Me.LblAcadStatus = New System.Windows.Forms.Label()
        Me.BtnPrepareLB = New System.Windows.Forms.Button()
        Me.LblEngravedex = New System.Windows.Forms.Label()
        Me.BtnGetBOM = New System.Windows.Forms.Button()
        Me.TxtBreakerSN = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabLB = New System.Windows.Forms.TabPage()
        Me.TabAcad = New System.Windows.Forms.TabPage()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.BtnAddToOrder = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtQty = New System.Windows.Forms.TextBox()
        Me.ComboBoxPrevDocs = New System.Windows.Forms.ComboBox()
        Me.BtnCreateDXF = New System.Windows.Forms.Button()
        Me.AcadTxtBox = New System.Windows.Forms.TextBox()
        Me.TabCreateCSV = New System.Windows.Forms.TabPage()
        Me.BtnOpenEditor = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCSVPN = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout
        Me.TabMain.SuspendLayout
        Me.Panel2.SuspendLayout
        Me.Panel5.SuspendLayout
        CType(Me.DataGridMain,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel3.SuspendLayout
        Me.Panel1.SuspendLayout
        Me.TabLB.SuspendLayout
        Me.TabAcad.SuspendLayout
        Me.TabCreateCSV.SuspendLayout
        Me.SuspendLayout
        '
        'txtLog
        '
        Me.txtLog.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtLog.Location = New System.Drawing.Point(843, 3)
        Me.txtLog.Multiline = true
        Me.txtLog.Name = "txtLog"
        Me.txtLog.Size = New System.Drawing.Size(279, 622)
        Me.txtLog.TabIndex = 1
        '
        'BtnLoadFile
        '
        Me.BtnLoadFile.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnLoadFile.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.BtnLoadFile.ForeColor = System.Drawing.SystemColors.Control
        Me.BtnLoadFile.Location = New System.Drawing.Point(18, 30)
        Me.BtnLoadFile.Name = "BtnLoadFile"
        Me.BtnLoadFile.Size = New System.Drawing.Size(127, 37)
        Me.BtnLoadFile.TabIndex = 2
        Me.BtnLoadFile.Text = "Load File"
        Me.BtnLoadFile.UseVisualStyleBackColor = false
        '
        'BtnForceLoad
        '
        Me.BtnForceLoad.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnForceLoad.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.BtnForceLoad.ForeColor = System.Drawing.SystemColors.Control
        Me.BtnForceLoad.Location = New System.Drawing.Point(18, 73)
        Me.BtnForceLoad.Name = "BtnForceLoad"
        Me.BtnForceLoad.Size = New System.Drawing.Size(127, 37)
        Me.BtnForceLoad.TabIndex = 3
        Me.BtnForceLoad.Text = "Force Load"
        Me.BtnForceLoad.UseVisualStyleBackColor = false
        '
        'BtnClose
        '
        Me.BtnClose.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnClose.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.BtnClose.ForeColor = System.Drawing.SystemColors.Control
        Me.BtnClose.Location = New System.Drawing.Point(18, 116)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(127, 37)
        Me.BtnClose.TabIndex = 4
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = false
        '
        'BtnForceClose
        '
        Me.BtnForceClose.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnForceClose.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.BtnForceClose.ForeColor = System.Drawing.SystemColors.Control
        Me.BtnForceClose.Location = New System.Drawing.Point(18, 159)
        Me.BtnForceClose.Name = "BtnForceClose"
        Me.BtnForceClose.Size = New System.Drawing.Size(127, 37)
        Me.BtnForceClose.TabIndex = 5
        Me.BtnForceClose.Text = "Force Close"
        Me.BtnForceClose.UseVisualStyleBackColor = false
        '
        'BtnStart
        '
        Me.BtnStart.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnStart.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.BtnStart.ForeColor = System.Drawing.SystemColors.Control
        Me.BtnStart.Location = New System.Drawing.Point(18, 202)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(127, 37)
        Me.BtnStart.TabIndex = 6
        Me.BtnStart.Text = "Start"
        Me.BtnStart.UseVisualStyleBackColor = false
        '
        'BtnStatus
        '
        Me.BtnStatus.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.BtnStatus.ForeColor = System.Drawing.SystemColors.Control
        Me.BtnStatus.Location = New System.Drawing.Point(18, 245)
        Me.BtnStatus.Name = "BtnStatus"
        Me.BtnStatus.Size = New System.Drawing.Size(127, 37)
        Me.BtnStatus.TabIndex = 7
        Me.BtnStatus.Text = "Status"
        Me.BtnStatus.UseVisualStyleBackColor = false
        '
        'BtnPing
        '
        Me.BtnPing.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnPing.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.BtnPing.ForeColor = System.Drawing.SystemColors.Control
        Me.BtnPing.Location = New System.Drawing.Point(18, 288)
        Me.BtnPing.Name = "BtnPing"
        Me.BtnPing.Size = New System.Drawing.Size(127, 37)
        Me.BtnPing.TabIndex = 8
        Me.BtnPing.Text = "Ping"
        Me.BtnPing.UseVisualStyleBackColor = false
        '
        'TxtFileName
        '
        Me.TxtFileName.Location = New System.Drawing.Point(151, 57)
        Me.TxtFileName.Name = "TxtFileName"
        Me.TxtFileName.Size = New System.Drawing.Size(353, 23)
        Me.TxtFileName.TabIndex = 9
        Me.TxtFileName.Text = "File Name"
        '
        'Timer1
        '
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabMain)
        Me.TabControl1.Controls.Add(Me.TabLB)
        Me.TabControl1.Controls.Add(Me.TabAcad)
        Me.TabControl1.Controls.Add(Me.TabCreateCSV)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1133, 656)
        Me.TabControl1.TabIndex = 11
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.Panel2)
        Me.TabMain.Controls.Add(Me.Panel3)
        Me.TabMain.Controls.Add(Me.Panel1)
        Me.TabMain.Location = New System.Drawing.Point(4, 24)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.Size = New System.Drawing.Size(1125, 628)
        Me.TabMain.TabIndex = 2
        Me.TabMain.Text = "Main"
        Me.TabMain.UseVisualStyleBackColor = true
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 89)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1125, 504)
        Me.Panel2.TabIndex = 4
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.DataGridMain)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1125, 504)
        Me.Panel5.TabIndex = 4
        '
        'DataGridMain
        '
        Me.DataGridMain.AllowUserToAddRows = false
        Me.DataGridMain.AllowUserToDeleteRows = false
        Me.DataGridMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DataGridMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartNum, Me.Desc, Me.Qty, Me.RunPrev})
        Me.DataGridMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridMain.Location = New System.Drawing.Point(0, 0)
        Me.DataGridMain.Name = "DataGridMain"
        Me.DataGridMain.ReadOnly = true
        Me.DataGridMain.RowTemplate.Height = 25
        Me.DataGridMain.Size = New System.Drawing.Size(1125, 504)
        Me.DataGridMain.TabIndex = 2
        '
        'PartNum
        '
        Me.PartNum.HeaderText = "Part Number"
        Me.PartNum.Name = "PartNum"
        Me.PartNum.ReadOnly = true
        '
        'Desc
        '
        Me.Desc.HeaderText = "Description"
        Me.Desc.Name = "Desc"
        Me.Desc.ReadOnly = true
        '
        'Qty
        '
        Me.Qty.HeaderText = "Quantity"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = true
        '
        'RunPrev
        '
        Me.RunPrev.HeaderText = "Run Prev"
        Me.RunPrev.Name = "RunPrev"
        Me.RunPrev.ReadOnly = true
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ProgressBarBOM)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 593)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1125, 35)
        Me.Panel3.TabIndex = 4
        '
        'ProgressBarBOM
        '
        Me.ProgressBarBOM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressBarBOM.Location = New System.Drawing.Point(0, 0)
        Me.ProgressBarBOM.Name = "ProgressBarBOM"
        Me.ProgressBarBOM.Size = New System.Drawing.Size(1125, 35)
        Me.ProgressBarBOM.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblLBStatus)
        Me.Panel1.Controls.Add(Me.LblAcadStatus)
        Me.Panel1.Controls.Add(Me.BtnPrepareLB)
        Me.Panel1.Controls.Add(Me.LblEngravedex)
        Me.Panel1.Controls.Add(Me.BtnGetBOM)
        Me.Panel1.Controls.Add(Me.TxtBreakerSN)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1125, 89)
        Me.Panel1.TabIndex = 3
        '
        'lblLBStatus
        '
        Me.lblLBStatus.AutoSize = true
        Me.lblLBStatus.Location = New System.Drawing.Point(857, 34)
        Me.lblLBStatus.Name = "lblLBStatus"
        Me.lblLBStatus.Size = New System.Drawing.Size(61, 15)
        Me.lblLBStatus.TabIndex = 11
        Me.lblLBStatus.Text = "LB Status: "
        '
        'LblAcadStatus
        '
        Me.LblAcadStatus.AutoSize = true
        Me.LblAcadStatus.Location = New System.Drawing.Point(857, 9)
        Me.LblAcadStatus.Name = "LblAcadStatus"
        Me.LblAcadStatus.Size = New System.Drawing.Size(75, 15)
        Me.LblAcadStatus.TabIndex = 5
        Me.LblAcadStatus.Text = "Acad Status: "
        '
        'BtnPrepareLB
        '
        Me.BtnPrepareLB.BackColor = System.Drawing.Color.DarkGray
        Me.BtnPrepareLB.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.BtnPrepareLB.ForeColor = System.Drawing.SystemColors.Control
        Me.BtnPrepareLB.Location = New System.Drawing.Point(468, 21)
        Me.BtnPrepareLB.Name = "BtnPrepareLB"
        Me.BtnPrepareLB.Size = New System.Drawing.Size(185, 39)
        Me.BtnPrepareLB.TabIndex = 4
        Me.BtnPrepareLB.Text = "Prepare LightBurn"
        Me.BtnPrepareLB.UseVisualStyleBackColor = false
        '
        'LblEngravedex
        '
        Me.LblEngravedex.AutoSize = true
        Me.LblEngravedex.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.LblEngravedex.Location = New System.Drawing.Point(468, 61)
        Me.LblEngravedex.Name = "LblEngravedex"
        Me.LblEngravedex.Size = New System.Drawing.Size(89, 20)
        Me.LblEngravedex.TabIndex = 3
        Me.LblEngravedex.Text = "Engravédex:"
        '
        'BtnGetBOM
        '
        Me.BtnGetBOM.BackColor = System.Drawing.Color.DarkGray
        Me.BtnGetBOM.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.BtnGetBOM.ForeColor = System.Drawing.SystemColors.Control
        Me.BtnGetBOM.Location = New System.Drawing.Point(333, 21)
        Me.BtnGetBOM.Name = "BtnGetBOM"
        Me.BtnGetBOM.Size = New System.Drawing.Size(115, 39)
        Me.BtnGetBOM.TabIndex = 2
        Me.BtnGetBOM.Text = "Get BOM"
        Me.BtnGetBOM.UseVisualStyleBackColor = false
        '
        'TxtBreakerSN
        '
        Me.TxtBreakerSN.Font = New System.Drawing.Font("Segoe UI", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TxtBreakerSN.Location = New System.Drawing.Point(126, 26)
        Me.TxtBreakerSN.Name = "TxtBreakerSN"
        Me.TxtBreakerSN.Size = New System.Drawing.Size(183, 29)
        Me.TxtBreakerSN.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(11, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Breaker SN:"
        '
        'TabLB
        '
        Me.TabLB.Controls.Add(Me.TxtFileName)
        Me.TabLB.Controls.Add(Me.BtnPing)
        Me.TabLB.Controls.Add(Me.BtnStatus)
        Me.TabLB.Controls.Add(Me.BtnStart)
        Me.TabLB.Controls.Add(Me.BtnForceClose)
        Me.TabLB.Controls.Add(Me.BtnClose)
        Me.TabLB.Controls.Add(Me.BtnForceLoad)
        Me.TabLB.Controls.Add(Me.BtnLoadFile)
        Me.TabLB.Controls.Add(Me.txtLog)
        Me.TabLB.Location = New System.Drawing.Point(4, 24)
        Me.TabLB.Name = "TabLB"
        Me.TabLB.Padding = New System.Windows.Forms.Padding(3)
        Me.TabLB.Size = New System.Drawing.Size(1125, 628)
        Me.TabLB.TabIndex = 0
        Me.TabLB.Text = "LightBurn"
        Me.TabLB.UseVisualStyleBackColor = true
        '
        'TabAcad
        '
        Me.TabAcad.Controls.Add(Me.BtnClear)
        Me.TabAcad.Controls.Add(Me.BtnAddToOrder)
        Me.TabAcad.Controls.Add(Me.Label2)
        Me.TabAcad.Controls.Add(Me.TxtQty)
        Me.TabAcad.Controls.Add(Me.ComboBoxPrevDocs)
        Me.TabAcad.Controls.Add(Me.BtnCreateDXF)
        Me.TabAcad.Controls.Add(Me.AcadTxtBox)
        Me.TabAcad.Location = New System.Drawing.Point(4, 24)
        Me.TabAcad.Name = "TabAcad"
        Me.TabAcad.Padding = New System.Windows.Forms.Padding(3)
        Me.TabAcad.Size = New System.Drawing.Size(1125, 628)
        Me.TabAcad.TabIndex = 1
        Me.TabAcad.Text = "Create Doc"
        Me.TabAcad.UseVisualStyleBackColor = true
        '
        'BtnClear
        '
        Me.BtnClear.Location = New System.Drawing.Point(118, 180)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(75, 23)
        Me.BtnClear.TabIndex = 9
        Me.BtnClear.Text = "Clear"
        Me.BtnClear.UseVisualStyleBackColor = true
        '
        'BtnAddToOrder
        '
        Me.BtnAddToOrder.Location = New System.Drawing.Point(118, 139)
        Me.BtnAddToOrder.Name = "BtnAddToOrder"
        Me.BtnAddToOrder.Size = New System.Drawing.Size(75, 23)
        Me.BtnAddToOrder.TabIndex = 8
        Me.BtnAddToOrder.Text = "Add to List"
        Me.BtnAddToOrder.UseVisualStyleBackColor = true
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(20, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Qty:"
        '
        'TxtQty
        '
        Me.TxtQty.Location = New System.Drawing.Point(52, 139)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Size = New System.Drawing.Size(60, 23)
        Me.TxtQty.TabIndex = 6
        '
        'ComboBoxPrevDocs
        '
        Me.ComboBoxPrevDocs.Font = New System.Drawing.Font("Segoe UI", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ComboBoxPrevDocs.FormattingEnabled = true
        Me.ComboBoxPrevDocs.Location = New System.Drawing.Point(18, 87)
        Me.ComboBoxPrevDocs.Name = "ComboBoxPrevDocs"
        Me.ComboBoxPrevDocs.Size = New System.Drawing.Size(295, 29)
        Me.ComboBoxPrevDocs.TabIndex = 5
        '
        'BtnCreateDXF
        '
        Me.BtnCreateDXF.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnCreateDXF.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.BtnCreateDXF.ForeColor = System.Drawing.SystemColors.Control
        Me.BtnCreateDXF.Location = New System.Drawing.Point(18, 30)
        Me.BtnCreateDXF.Name = "BtnCreateDXF"
        Me.BtnCreateDXF.Size = New System.Drawing.Size(127, 37)
        Me.BtnCreateDXF.TabIndex = 3
        Me.BtnCreateDXF.Text = "Create DXF"
        Me.BtnCreateDXF.UseVisualStyleBackColor = false
        '
        'AcadTxtBox
        '
        Me.AcadTxtBox.Dock = System.Windows.Forms.DockStyle.Right
        Me.AcadTxtBox.Location = New System.Drawing.Point(806, 3)
        Me.AcadTxtBox.Multiline = true
        Me.AcadTxtBox.Name = "AcadTxtBox"
        Me.AcadTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.AcadTxtBox.Size = New System.Drawing.Size(316, 622)
        Me.AcadTxtBox.TabIndex = 2
        '
        'TabCreateCSV
        '
        Me.TabCreateCSV.Controls.Add(Me.BtnOpenEditor)
        Me.TabCreateCSV.Controls.Add(Me.Label4)
        Me.TabCreateCSV.Controls.Add(Me.txtCSVPN)
        Me.TabCreateCSV.Location = New System.Drawing.Point(4, 24)
        Me.TabCreateCSV.Name = "TabCreateCSV"
        Me.TabCreateCSV.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCreateCSV.Size = New System.Drawing.Size(1125, 628)
        Me.TabCreateCSV.TabIndex = 3
        Me.TabCreateCSV.Text = "Create/Edit CSV"
        Me.TabCreateCSV.UseVisualStyleBackColor = true
        '
        'BtnOpenEditor
        '
        Me.BtnOpenEditor.Location = New System.Drawing.Point(309, 28)
        Me.BtnOpenEditor.Name = "BtnOpenEditor"
        Me.BtnOpenEditor.Size = New System.Drawing.Size(98, 23)
        Me.BtnOpenEditor.TabIndex = 4
        Me.BtnOpenEditor.Text = "Open Editor"
        Me.BtnOpenEditor.UseVisualStyleBackColor = true
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Location = New System.Drawing.Point(7, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Part Number:"
        '
        'txtCSVPN
        '
        Me.txtCSVPN.Location = New System.Drawing.Point(113, 25)
        Me.txtCSVPN.Name = "txtCSVPN"
        Me.txtCSVPN.Size = New System.Drawing.Size(181, 23)
        Me.txtCSVPN.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7!, 15!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1133, 656)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TabControl1.ResumeLayout(false)
        Me.TabMain.ResumeLayout(false)
        Me.Panel2.ResumeLayout(false)
        Me.Panel5.ResumeLayout(false)
        CType(Me.DataGridMain,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel3.ResumeLayout(false)
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        Me.TabLB.ResumeLayout(false)
        Me.TabLB.PerformLayout
        Me.TabAcad.ResumeLayout(false)
        Me.TabAcad.PerformLayout
        Me.TabCreateCSV.ResumeLayout(false)
        Me.TabCreateCSV.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents txtLog As TextBox
    Friend WithEvents BtnLoadFile As Button
    Friend WithEvents BtnForceLoad As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnForceClose As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents BtnStatus As Button
    Friend WithEvents BtnPing As Button
    Friend WithEvents TxtFileName As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabLB As TabPage
    Friend WithEvents TabAcad As TabPage
    Friend WithEvents BtnCreateDXF As Button
    Friend WithEvents AcadTxtBox As TextBox
    Friend WithEvents ComboBoxPrevDocs As ComboBox
    Friend WithEvents TabMain As TabPage
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DataGridMain As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TxtBreakerSN As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PartNum As DataGridViewTextBoxColumn
    Friend WithEvents Desc As DataGridViewTextBoxColumn
    Friend WithEvents Qty As DataGridViewTextBoxColumn
    Friend WithEvents RunPrev As DataGridViewTextBoxColumn
    Friend WithEvents BtnGetBOM As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ProgressBarBOM As ProgressBar
    Friend WithEvents LblEngravedex As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents BtnPrepareLB As Button
    Friend WithEvents lblLBStatus As Label
    Friend WithEvents LblAcadStatus As Label
    Friend WithEvents BtnAddToOrder As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtQty As TextBox
    Friend WithEvents BtnClear As Button
    Friend WithEvents TabCreateCSV As TabPage
    Friend WithEvents BtnOpenEditor As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCSVPN As TextBox
End Class
