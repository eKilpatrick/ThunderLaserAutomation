<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VariantCSV
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TextInfo1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComboBoxBaseTemplates = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblActivePN = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PanelVisual = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.LblText = New System.Windows.Forms.Label()
        Me.LblWidth = New System.Windows.Forms.Label()
        Me.LblHeight = New System.Windows.Forms.Label()
        Me.LblHoleDiam = New System.Windows.Forms.Label()
        Me.BtnCreateCSV = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TextInfo1, Me.Qty})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 25
        Me.DataGridView1.Size = New System.Drawing.Size(562, 411)
        Me.DataGridView1.TabIndex = 0
        '
        'TextInfo1
        '
        Me.TextInfo1.HeaderText = "Text Info"
        Me.TextInfo1.Name = "TextInfo1"
        '
        'Qty
        '
        Me.Qty.HeaderText = "Quantity"
        Me.Qty.Name = "Qty"
        '
        'ComboBoxBaseTemplates
        '
        Me.ComboBoxBaseTemplates.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ComboBoxBaseTemplates.FormattingEnabled = True
        Me.ComboBoxBaseTemplates.Location = New System.Drawing.Point(172, 36)
        Me.ComboBoxBaseTemplates.Name = "ComboBoxBaseTemplates"
        Me.ComboBoxBaseTemplates.Size = New System.Drawing.Size(233, 29)
        Me.ComboBoxBaseTemplates.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(30, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Base Template:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LblActivePN)
        Me.Panel1.Controls.Add(Me.ComboBoxBaseTemplates)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(762, 100)
        Me.Panel1.TabIndex = 3
        '
        'LblActivePN
        '
        Me.LblActivePN.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblActivePN.AutoSize = True
        Me.LblActivePN.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.LblActivePN.Location = New System.Drawing.Point(426, 0)
        Me.LblActivePN.Name = "LblActivePN"
        Me.LblActivePN.Size = New System.Drawing.Size(76, 20)
        Me.LblActivePN.TabIndex = 3
        Me.LblActivePN.Text = "Active PN:"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.BtnCreateCSV)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 100)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 411)
        Me.Panel2.TabIndex = 4
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.PanelVisual)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 39)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(200, 372)
        Me.Panel4.TabIndex = 7
        '
        'PanelVisual
        '
        Me.PanelVisual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelVisual.Location = New System.Drawing.Point(0, 0)
        Me.PanelVisual.Name = "PanelVisual"
        Me.PanelVisual.Size = New System.Drawing.Size(200, 278)
        Me.PanelVisual.TabIndex = 7
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.LblText)
        Me.Panel5.Controls.Add(Me.LblWidth)
        Me.Panel5.Controls.Add(Me.LblHeight)
        Me.Panel5.Controls.Add(Me.LblHoleDiam)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 278)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(200, 94)
        Me.Panel5.TabIndex = 0
        '
        'LblText
        '
        Me.LblText.AutoSize = True
        Me.LblText.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.LblText.Location = New System.Drawing.Point(6, 64)
        Me.LblText.Name = "LblText"
        Me.LblText.Size = New System.Drawing.Size(70, 21)
        Me.LblText.TabIndex = 3
        Me.LblText.Text = "# of Text:"
        '
        'LblWidth
        '
        Me.LblWidth.AutoSize = True
        Me.LblWidth.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.LblWidth.Location = New System.Drawing.Point(6, 24)
        Me.LblWidth.Name = "LblWidth"
        Me.LblWidth.Size = New System.Drawing.Size(55, 21)
        Me.LblWidth.TabIndex = 2
        Me.LblWidth.Text = "Width:"
        '
        'LblHeight
        '
        Me.LblHeight.AutoSize = True
        Me.LblHeight.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.LblHeight.Location = New System.Drawing.Point(6, 3)
        Me.LblHeight.Name = "LblHeight"
        Me.LblHeight.Size = New System.Drawing.Size(59, 21)
        Me.LblHeight.TabIndex = 1
        Me.LblHeight.Text = "Height:"
        '
        'LblHoleDiam
        '
        Me.LblHoleDiam.AutoSize = True
        Me.LblHoleDiam.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.LblHoleDiam.Location = New System.Drawing.Point(6, 43)
        Me.LblHoleDiam.Name = "LblHoleDiam"
        Me.LblHoleDiam.Size = New System.Drawing.Size(113, 21)
        Me.LblHoleDiam.TabIndex = 0
        Me.LblHoleDiam.Text = "Hole Diameter:"
        '
        'BtnCreateCSV
        '
        Me.BtnCreateCSV.BackColor = System.Drawing.Color.DarkGray
        Me.BtnCreateCSV.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnCreateCSV.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.BtnCreateCSV.ForeColor = System.Drawing.SystemColors.Control
        Me.BtnCreateCSV.Location = New System.Drawing.Point(0, 0)
        Me.BtnCreateCSV.Name = "BtnCreateCSV"
        Me.BtnCreateCSV.Size = New System.Drawing.Size(200, 39)
        Me.BtnCreateCSV.TabIndex = 6
        Me.BtnCreateCSV.Text = "Create CSV"
        Me.BtnCreateCSV.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.DataGridView1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(200, 100)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(562, 411)
        Me.Panel3.TabIndex = 5
        '
        'VariantCSV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(762, 511)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "VariantCSV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ComboBoxBaseTemplates As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents LblActivePN As Label
    Friend WithEvents BtnCreateCSV As Button
    Friend WithEvents TextInfo1 As DataGridViewTextBoxColumn
    Friend WithEvents Qty As DataGridViewTextBoxColumn
    Friend WithEvents PanelVisual As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents LblWidth As Label
    Friend WithEvents LblHeight As Label
    Friend WithEvents LblHoleDiam As Label
    Friend WithEvents LblText As Label
End Class
