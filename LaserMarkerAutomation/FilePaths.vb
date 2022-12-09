Module FilePaths
    Public ThunderPath As String = "\\ad101.siemens-energy.net\dfs101\File_SE\NAM\RCH_Public\Co-ops\ThunderLaser\"

    Public batPath As String = ThunderPath & "RUNNING_CODE\CreateMarkingStrip.bat"
    Public MarkingStripInfoPath As String = ThunderPath & "RUNNING_CODE\MarkingStripInfo.txt"
    Public blankDXFPath As String = ThunderPath & "RUNNING_CODE\Blank.dxf"
    Public CurrentDXFPath As String = ThunderPath & "RUNNING_CODE\CurrentfILE.dxf"
    Public NestingBatPath As String = ThunderPath & "RUNNING_CODE\RunNesting.bat"

    Public acadPath As String = "C:\Program Files\Autodesk\AutoCAD 2023\acad.exe"
    Public acadInactivePath As String = "C:\Program Files\Autodesk\AutoCAD 2023\Support\acaddoc_NOTRUN_LASER.lsp"
    Public acadActivePath As String = "C:\Program Files\Autodesk\AutoCAD 2023\Support\acaddoc.lsp"
    Public ScriptCompletePath As String = "C:\Program Files\Autodesk\AutoCAD 2023\Support\ScriptComplete.txt"

    Public TemplatesPath As String = ThunderPath & "UniqueTemplates\Templates.csv"
    Public PrevDocsPath As String = ThunderPath & "PartNumbers\"

    Public AstraWritePath As String = "C:\Temp\Test.xml"
    Public AstraReadPath As String = "C:\Temp\AstraOut.xml"
    Public AstraExePath As String = "C:\Program Files (x86)\Astra R-Nesting\Astra.exe"
End Module
