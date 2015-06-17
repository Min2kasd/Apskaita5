Public Module Constants

    Friend Const KeyCompanyInfo As String = "CompanyInfo"

    Public Const LanguageCodeLith As String = "LT"

    Public Const TokenInvoiceForm As String = "INV"
    Public Const TokenCompanyLogo As String = "LOG"

    Friend Const FinancialStatementsRootName As String = "Finansinė atskaitomybė"
    Friend Const BalanceStatementRootName As String = "Balanso ataskaita"
    Friend Const BalanceAssetsStatementRootName As String = "TURTAS"
    Friend Const BalanceCapitalStatementRootName As String = "NUOSAVYBĖ IR ĮSIPAREIGOJIMAI"
    Friend Const IncomeStatementRootName As String = "Pelno (nuostolio) ataskaita"
    Friend Const IncomeStatementFirstItemRootName As String = "GRYNASIS PELNAS (NUOSTOLIAI)"

    Friend Const SINGLEVALUESETTINGSSLOT As String = "SingleValueSettings"
    Friend Const TAXRATESSSLOT As String = "TaxRatesSettings"

    Friend Const SETTINGSFILENAME As String = "CommonSettings.xmls"
    Friend Const PULICCODESFILENAME As String = "CommonCodes.dat"
    Friend Const C_ACCOUNTS_FILE As String = "tsp.dat"
    Friend Const FINANCIALSTATEMENTS_FILE As String = "FinancialStatements_Short.str"
    Friend Const WORKTIMEDATA_FILE As String = "WorkTime.dat"
    Friend Const PUBLICHOLIDAYSDATA_FILE As String = "PublicHolidays.dat"
    Friend Const WORKTIMECLASSES_FILE As String = "WTClasses.dat"

    Friend Const VMICODESGPMSLOT As String = "GPMCodes"
    Friend Const SODRACODESGPMSLOT As String = "SODRACodes"
    Friend Const MUNICIPALITIESCODESSLOT As String = "MunicipalityCodes"
    Friend Const SODRABRANCHESSLOT As String = "SODRABranches"
    Friend Const CLASESESTATESLOT As String = "AmortizationGroups"

    Public Const FILENAMEFFDATATEMP As String = "\FFData\temp.ffdata"
    Public Const FILENAMEFFDATASAM01 As String = "\FFData\SAM-v01.ffdata"
    Public Const FILENAMEFFDATAFR0572_2 As String = "\FFData\FR0572.ffdata"
    Public Const FILENAMEFFDATAFR0572_3 As String = "\FFData\FR0572(3).ffdata"
    Public Const FILENAMEFFDATAFR0572_4 As String = "\FFData\FR0572(4).ffdata"
    Public Const FILENAMEFFDATAFR0573_2 As String = "\FFData\FR0573.ffdata"
    Public Const FILENAMEFFDATAFR0573_3 As String = "\FFData\FR0573(3).ffdata"
    Public Const FILENAMEFFDATAFR0573_4 As String = "\FFData\FR0573(4).ffdata"
    Public Const FILENAMEFFDATASD13_1 As String = "\FFData\13-SD-v01.ffdata"
    Public Const FILENAMEFFDATASD13_2 As String = "\FFData\13-SD-v02.ffdata"
    Public Const FILENAMEFFDATASD13_5 As String = "\FFData\13-SD-v05.ffdata"
    Public Const FILENAMEFFDATASAM02 As String = "\FFData\SAM-v02.ffdata"
    Public Const FILENAMEFFDATASAM03 As String = "\FFData\SAM-v03.ffdata"
    Public Const FILENAMEFFDATASAM04 As String = "\FFData\SAM-v04.ffdata"
    Public Const FILENAMEFFDATAFR0671 As String = "\FFData\FR0671.ffdata"
    Public Const FILENAMEFFDATAFR0671_2 As String = "\FFData\FR0671(2).ffdata"
    Public Const FILENAMEFFDATAFR0672 As String = "\FFData\FR0672.ffdata"
    Public Const FILENAMEFFDATAFR0672_2 As String = "\FFData\FR0672(2).ffdata"
    Public Const FILENAMEMXFDSAM01 As String = "\MXFD\SAM-v01.mxfd"
    Public Const FILENAMEMXFDFR0572_2 As String = "\MXFD\FR0572(2).mxfd"
    Public Const FILENAMEMXFDFR0572_3 As String = "\MXFD\FR0572(3).mxfd"
    Public Const FILENAMEMXFDFR0572_4 As String = "\MXFD\FR0572(4).mxfd"
    Public Const FILENAMEMXFDFR0573_2 As String = "\MXFD\FR0573(2).mxfd"
    Public Const FILENAMEMXFDFR0573_3 As String = "\MXFD\FR0573(3).mxfd"
    Public Const FILENAMEMXFDFR0573_4 As String = "\MXFD\FR0573(4).mxfd"
    Public Const FILENAMEMXFDSD13_1 As String = "\MXFD\13-SD-v01.mxfd"
    Public Const FILENAMEMXFDSD13_2 As String = "\MXFD\13-SD-v02.mxfd"
    Public Const FILENAMEMXFDSD13_5 As String = "\MXFD\13-SD-v05.mxfd"
    Public Const FILENAMEMXFDSAM02 As String = "\MXFD\SAM-v02.mxfd"
    Public Const FILENAMEMXFDSAM03 As String = "\MXFD\SAM-v03.mxfd"
    Public Const FILENAMEMXFDSAM04 As String = "\MXFD\SAM-v04.mxfd"
    Public Const FILENAMEMXFDFR0671 As String = "\MXFD\FR0671.mxfd"
    Public Const FILENAMEMXFDFR0671_2 As String = "\MXFD\FR0671(2).mxfd"
    Public Const FILENAMEMXFDFR0672 As String = "\MXFD\FR0672.mxfd"
    Public Const FILENAMEMXFDFR0672_2 As String = "\MXFD\FR0672(2).mxfd"

    Public Const AVERAGEDAYSINYEAR As Integer = 365

    Public Const ROUNDCURRENCYRATE As Integer = 6
    Public Const ROUNDUNITINVOICEMADE As Integer = 4
    Public Const ROUNDAMOUNTINVOICEMADE As Integer = 4
    Public Const ROUNDUNITINVOICERECEIVED As Integer = 4
    Public Const ROUNDAMOUNTINVOICERECEIVED As Integer = 4
    Public Const ROUNDUNITASSET As Integer = 4
    Public Const ROUNDWORKTIME As Integer = 4
    Public Const ROUNDAMOUNTGOODS As Integer = 6
    Public Const ROUNDUNITGOODS As Integer = 6
    Public Const ROUNDWORKHOURS As Integer = 4
    Public Const ROUNDWORKLOAD As Integer = 4
    Public Const ROUNDACCUMULATEDHOLIDAY As Integer = 4
    Public Const ROUNDWORKDAYSRATIO As Integer = 4
    Public Const ROUNDWORKYEARS As Integer = 4
    Public Const ROUNDHOLIDAYDAYS As Integer = 4

    Public Const TILLINCOMEORDERFULLNUMBERFORMATWITHDATE As String = "{0}-{1}"
    Public Const TILLINCOMEORDERDATEFORMATINNUMBER As String = "yyyyMMdd"
    Public Const TILLSPENDINGSORDERFULLNUMBERFORMATWITHDATE As String = "{0}-{1}"
    Public Const TILLSPENDINGSORDERDATEFORMATINNUMBER As String = "yyyyMMdd"

End Module
