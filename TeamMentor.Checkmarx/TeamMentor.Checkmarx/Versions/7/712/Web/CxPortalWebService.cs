//O2File:CxPortalWebService.cs

using System;
using System.Web.Services;
using FluentSharp.CoreLib;
using log4net;
using TeamMentor.Checkmarx;

namespace Checkmarx712Web
{
[WebService(Namespace = "http://Checkmarx.com")]
public class CxPortalWebService
{
	public CxPortalWebService_Proxy _web_Service { get; set; }
    private ILog log = LogManager.GetLogger(typeof(CxPortalWebService));
	public CxPortalWebService()
	{
        var config = new CXConfiguration();
        var data = config.secretData_Load();
	    if (data.notNull())
	    {
	        var uri = new Uri(data.CheckMarx_WebService_EndPoint);
            var endpoint = uri.hostUrl() + ":" + uri.Port + "/cxwebinterface/Portal/CxWebService.asmx";
	        log.Debug("[PortalWebService] Original Portal EndPoint located at =>" + endpoint);
	        _web_Service = new CxPortalWebService_Proxy(endpoint);
	    }
	    else
	    {
            log.Error("[PortalWebService] Configuration file was not found");
            throw new Exception("[PortalWebService] Configuration file was not found");
	    }

	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateCompanyProperties(string sessionID, string companyID, string companyName, int maxReviewers, int maxScanners, int maxManagers)
	{
	    log.Debug("[PortalWebService] Inside UpdateCompanyProperties");
		CxWSBasicRepsonse result = _web_Service.UpdateCompanyProperties(sessionID, companyID, companyName, maxReviewers, maxScanners, maxManagers);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse SetSystemSettings(string sessionID, SystemSettings settings)
	{
	    log.Debug("[PortalWebService] Inside SetSystemSettings");
		CxWSBasicRepsonse result = _web_Service.SetSystemSettings(sessionID, settings);
		return result;
	}
	[WebMethod()]
	public CxWSResponseSystemLanguages GetServerLanguageList(string sessionID)
	{
	    log.Debug("[PortalWebService] Inside GetServerLanguageList");
		CxWSResponseSystemLanguages result = _web_Service.GetServerLanguageList(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWsResponseSystemSettings GetSystemSettings(string sessionID)
	{
	    log.Debug("[PortalWebService] Inside GetSystemSettings");
		CxWsResponseSystemSettings result = _web_Service.GetSystemSettings(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse VerifySupportedVersion(CxClientType clientType, string clientVersion, string APIVersion)
	{
	    log.Debug("[PortalWebService] Inside VerifySupportedVersion");
		CxWSBasicRepsonse result = _web_Service.VerifySupportedVersion(clientType, clientVersion, APIVersion);
		return result;
	}
	[WebMethod()]
	public CxWSResponseInstallationSettings GetInstallationSettings(string sessionID)
	{   
	    log.Debug("[PortalWebService] Inside GetInstallationSettings");
		CxWSResponseInstallationSettings result = _web_Service.GetInstallationSettings(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponsePresetList GetPresetList(string SessionID)
	{
	log.Debug("[PortalWebService] Inside GetPresetList");
		CxWSResponsePresetList result = _web_Service.GetPresetList(SessionID);
		return result;
	}
	[WebMethod()]
	public CxQueryCollectionResponse GetQueryCollection(string sessionId)
	{
	    log.Debug("[PortalWebService] Inside GetQueryCollection");
		CxQueryCollectionResponse result = _web_Service.GetQueryCollection(sessionId);
		return result;
	}
	[WebMethod()]
	public CxWSResponsePresetDetails GetPresetDetails(string sessionId, long id)
	{
	    log.Debug("[PortalWebService] Inside GetPresetDetails");
		CxWSResponsePresetDetails result = _web_Service.GetPresetDetails(sessionId, id);
		return result;
	}
	[WebMethod()]
	public CxWSResponsePresetDetails CreateNewPreset(string sessionId, CxPresetDetails presrt)
	{
	    log.Debug("[PortalWebService] Inside CreateNewPreset");
		CxWSResponsePresetDetails result = _web_Service.CreateNewPreset(sessionId, presrt);
		return result;
	}
	[WebMethod()]
	public CxWSResponsePresetDetails UpdatePreset(string sessionId, CxPresetDetails presrt)
	{
	    log.Debug("[PortalWebService] Inside UpdatePreset");
		CxWSResponsePresetDetails result = _web_Service.UpdatePreset(sessionId, presrt);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse DeletePreset(string sessionId, long id)
	{
        log.Debug("[PortalWebService] Inside DeletePreset");
		CxWSBasicRepsonse result = _web_Service.DeletePreset(sessionId, id);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse IsValidPresetName(string sessionID, string presetName)
	{
        log.Debug("[PortalWebService] Inside IsValidPresetName");
		CxWSBasicRepsonse result = _web_Service.IsValidPresetName(sessionID, presetName);
		return result;
	}
	[WebMethod()]
	public CxWSResponceQuerisForScan GetQueriesForScan(string sessionID, long scanId)
	{
		log.Debug("[PortalWebService] Inside GetQueriesForScan");
		CxWSResponceQuerisForScan result = _web_Service.GetQueriesForScan(sessionID, scanId);
        if (result != null && result.Queries != null)
        {
            new Checkmarx712Web.CxTeamMentor().TMFilterFor_CxWSResponceQuerisForScan(result);
        }
		return result;
	}
	[WebMethod()]
	public CxWSResponceQuerisForScanAndId GetQueriesForScanByRunId(string sessionID, string runId)
	{
		log.Debug("[CxPortalWebService]- Inside GetQueriesForScanByRunId");
		CxWSResponceQuerisForScanAndId result = _web_Service.GetQueriesForScanByRunId(sessionID, runId);
        if (result != null && result.Queries != null)
        {
            new CxTeamMentor().TMFilterFor_CxWSResponceQuerisForScanAndId(result);
        }
		return result;
	}
	[WebMethod()]
	public CxWSResponceScanResults GetResultsForQuery(string sessionID, long scanId, long queryId)
	{
        log.Debug("[CxPortalWebService]- Inside GetResultsForQuery");
		CxWSResponceScanResults result = _web_Service.GetResultsForQuery(sessionID, scanId, queryId);
		return result;
	}
	[WebMethod()]
	public CxWSResponceScanResults GetResultsForQueryQroup(string sessionID, long scanId, long queryGroupId)
	{
        log.Debug("[CxPortalWebService]- Inside GetResultsForQueryQroup");
		CxWSResponceScanResults result = _web_Service.GetResultsForQueryQroup(sessionID, scanId, queryGroupId);
		return result;
	}
	[WebMethod()]
	public CxWSResponceScanResults GetResultsForScanByLanguage(string sessionID, long scanId, string Language)
	{
        log.Debug("[CxPortalWebService]- Inside GetResultsForScanByLanguage");
		CxWSResponceScanResults result = _web_Service.GetResultsForScanByLanguage(sessionID, scanId, Language);
		return result;
	}
	[WebMethod()]
	public CxWSResponceScanResults GetResultsForScan(string sessionID, long scanId)
	{
        log.Debug("[CxPortalWebService]- Inside GetResultsForScan");
		CxWSResponceScanResults result = _web_Service.GetResultsForScan(sessionID, scanId);
		return result;
	}
	[WebMethod()]
	public CxWSResponceResultPath GetResultPath(string sessionId, long scanId, long pathId)
	{
        log.Debug("[CxPortalWebService]- Inside GetResultPath");
		CxWSResponceResultPath result = _web_Service.GetResultPath(sessionId, scanId, pathId);
		return result;
	}
	[WebMethod()]
	public CxWSResponceFileNames GetFileNamesForPath(string sessionId, long scanId, long pathId)
	{
        log.Debug("[CxPortalWebService]- Inside GetFileNamesForPath");
		CxWSResponceFileNames result = _web_Service.GetFileNamesForPath(sessionId, scanId, pathId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseResultPaths GetResultPathsForQuery(string sessionId, long scanId, long queryId)
	{
        log.Debug("[CxPortalWebService]- Inside GetResultPathsForQuery");
		CxWSResponseResultPaths result = _web_Service.GetResultPathsForQuery(sessionId, scanId, queryId);
		return result;
	}
	[WebMethod()]
	public CxWSResponceScanResults GetResultsBySeverity(string sessionId, long scanId, int Severity, string Language)
	{
        log.Debug("[CxPortalWebService]- Inside GetResultsBySeverity");
		CxWSResponceScanResults result = _web_Service.GetResultsBySeverity(sessionId, scanId, Severity, Language);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse SavePredefinedCommands(string sessionID, CxPredefinedCommand[] predefinedCommands)
	{
        log.Debug("[CxPortalWebService]- Inside SavePredefinedCommands");
		CxWSBasicRepsonse result = _web_Service.SavePredefinedCommands(sessionID, predefinedCommands);
		return result;
	}
	[WebMethod()]
	public CxWSResponsePredefinedCommands GetPredefinedCommands(string sessionId)
	{
        log.Debug("[CxPortalWebService]- Inside GetPredefinedCommands");
		CxWSResponsePredefinedCommands result = _web_Service.GetPredefinedCommands(sessionId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseNameList GetExecutableList(string sessionId)
	{
        log.Debug("[CxPortalWebService]- Inside GetExecutableList");
		CxWSResponseNameList result = _web_Service.GetExecutableList(sessionId);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdatePermission(string sessionID, CxPermission permission, string teamId)
	{
        log.Debug("[CxPortalWebService]- Inside UpdatePermission");
		CxWSBasicRepsonse result = _web_Service.UpdatePermission(sessionID, permission, teamId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseUserData GetProjectAssignUsers(string sessionID, long projectId)
	{
        log.Debug("[CxPortalWebService]- Inside GetProjectAssignUsers");
		CxWSResponseUserData result = _web_Service.GetProjectAssignUsers(sessionID, projectId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseBool IsAllowAutoSignIn()
	{
        log.Debug("[CxPortalWebService]- Inside IsAllowAutoSignIn");
		CxWSResponseBool result = _web_Service.IsAllowAutoSignIn();
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse SaveSubsetResults(string sessionId, long projectId, long ScanId, long[] pathIds, string comments)
	{
        log.Debug("[CxPortalWebService]- Inside SaveSubsetResults");
		CxWSBasicRepsonse result = _web_Service.SaveSubsetResults(sessionId, projectId, ScanId, pathIds, comments);
		return result;
	}
	[WebMethod()]
	public CxWSResponsePivotTable GetPivotData(string SessionID, CxPivotDataRequest PivotParams)
	{
        log.Debug("[CxPortalWebService]- Inside GetPivotData");
		CxWSResponsePivotTable result = _web_Service.GetPivotData(SessionID, PivotParams);
		return result;
	}
	[WebMethod()]
	public CxWSResponsePivotLayouts GetPivotLayouts(string SessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetPivotLayouts");
		CxWSResponsePivotLayouts result = _web_Service.GetPivotLayouts(SessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse SavePivotLayout(string SessionID, CxPivotLayout layout)
	{
        log.Debug("[CxPortalWebService]- Inside SavePivotLayout");
		CxWSBasicRepsonse result = _web_Service.SavePivotLayout(SessionID, layout);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse DeletePivotLayout(string SessionID, long LayoutID)
	{
        log.Debug("[CxPortalWebService]- Inside DeletePivotLayout");
		CxWSBasicRepsonse result = _web_Service.DeletePivotLayout(SessionID, LayoutID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseShortQueryDescription GetQueryShortDescription(string sessionId, long queryId)
	{
        log.Debug("[CxPortalWebService]- Inside DeletePivotGetQueryShortDescriptionLayout");
		CxWSResponseShortQueryDescription result = _web_Service.GetQueryShortDescription(sessionId, queryId);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse RegisterSaasPendingUser(SaasPendingUser pendingUser, string activationPageUrl)
	{
        log.Debug("[CxPortalWebService]- Inside RegisterSaasPendingUser");
		CxWSBasicRepsonse result = _web_Service.RegisterSaasPendingUser(pendingUser, activationPageUrl);
		return result;
	}
	[WebMethod()]
	public CxWSResponseSaasLoginData ActivateSaasUser(string userToken)
	{
        log.Debug("[CxPortalWebService]- Inside ActivateSaasUser");
		CxWSResponseSaasLoginData result = _web_Service.ActivateSaasUser(userToken);
		return result;
	}
	[WebMethod()]
	public CxWSResponseSaasPackage GetSaasPackages()
	{
        log.Debug("[CxPortalWebService]- Inside GetSaasPackages");
		CxWSResponseSaasPackage result = _web_Service.GetSaasPackages();
		return result;
	}
	[WebMethod()]
	public CxWSResponseSaasPackage GetTeamSaaSPackage(string teamId)
	{
        log.Debug("[CxPortalWebService]- Inside GetTeamSaaSPackage");
		CxWSResponseSaasPackage result = _web_Service.GetTeamSaaSPackage(teamId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseSaasLoginData SaasLogin(Credentials applicationCredentials, int lcid)
	{
        log.Debug("[CxPortalWebService]- Inside SaasLogin");
		CxWSResponseSaasLoginData result = _web_Service.SaasLogin(applicationCredentials, lcid);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse SendEmailForSales(string sessionID, EmailForSalesData emailData)
	{
        log.Debug("[CxPortalWebService]- Inside SendEmailForSales");
		CxWSBasicRepsonse result = _web_Service.SendEmailForSales(sessionID, emailData);
		return result;
	}
	[WebMethod()]
	public CxWSResponseEngineServers GetEngineServers(string sessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetEngineServers");
		CxWSResponseEngineServers result = _web_Service.GetEngineServers(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateEngineServer(string sessionID, CxEngineServer engine)
	{
        log.Debug("[CxPortalWebService]- Inside UpdateEngineServer");
		CxWSBasicRepsonse result = _web_Service.UpdateEngineServer(sessionID, engine);
		return result;
	}
	[WebMethod()]
	public CxWSResponseEngineServerId CreateEngineServer(string sessionID, CxEngineServer engine)
	{
        log.Debug("[CxPortalWebService]- Inside CreateEngineServer");
		CxWSResponseEngineServerId result = _web_Service.CreateEngineServer(sessionID, engine);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse DeleteEngineServer(string sessionID, long id)
	{
        log.Debug("[CxPortalWebService]- Inside DeleteEngineServer");
		CxWSBasicRepsonse result = _web_Service.DeleteEngineServer(sessionID, id);
		return result;
	}
	[WebMethod()]
	public CxWSResponseRunID Scan(string sessionId, CliScanArgs args)
	{
        log.Debug("[CxPortalWebService]- Inside Scan");
		CxWSResponseRunID result = _web_Service.Scan(sessionId, args);
		return result;
	}
	[WebMethod()]
	public CxWSResponseQueries ExportQueries(string sessionId, long[] queryIds)
	{
        log.Debug("[CxPortalWebService]- Inside ExportQueries");
		CxWSResponseQueries result = _web_Service.ExportQueries(sessionId, queryIds);
		return result;
	}
	[WebMethod()]
	public CxWSResponsePreset ExportPreset(string sessionId, long presetId)
	{
        log.Debug("[CxPortalWebService]- Inside ExportPreset");
		CxWSResponsePreset result = _web_Service.ExportPreset(sessionId, presetId);
		return result;
	}
	[WebMethod()]
	public CxWSImportQueriesRepsonse ImportQueries(string sessionId, 	[System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
byte[] importedFile)
	{
        log.Debug("[CxPortalWebService]- Inside ImportQueries");
		CxWSImportQueriesRepsonse result = _web_Service.ImportQueries(sessionId, importedFile);
		return result;
	}
	[WebMethod()]
	public CxWSImportQueriesRepsonse GetImportQueriesStatus(string sessionId, long requestId)
	{
        log.Debug("[CxPortalWebService]- Inside GetImportQueriesStatus");
		CxWSImportQueriesRepsonse result = _web_Service.GetImportQueriesStatus(sessionId, requestId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseTransportedQueries GetExistingQueries(string sessionId, 	[System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
byte[] importedFile)
	{
        log.Debug("[CxPortalWebService]- Inside GetExistingQueries");
		CxWSResponseTransportedQueries result = _web_Service.GetExistingQueries(sessionId, importedFile);
		return result;
	}
	[WebMethod()]
	public CxWSResponseExistsingTransportedPresetQueries GetExistingPresetQueries(string sessionId, 	[System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
byte[] importedFile)
	{
        log.Debug("[CxPortalWebService]- Inside GetExistingPresetQueries");
		CxWSResponseExistsingTransportedPresetQueries result = _web_Service.GetExistingPresetQueries(sessionId, importedFile);
		return result;
	}
	[WebMethod()]
	public CxWSImportQueriesRepsonse ImportPreset(string sessionId, 	[System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
byte[] importedFile)
	{
        log.Debug("[CxPortalWebService]- Inside ImportPreset");
		CxWSImportQueriesRepsonse result = _web_Service.ImportPreset(sessionId, importedFile);
		return result;
	}
	[WebMethod()]
	public CxWSCreateReportResponse CreateScanReport(string SessionID, CxWSFilteredReportRequest Report)
	{
        log.Debug("[CxPortalWebService]- Inside CreateScanReport");
		CxWSCreateReportResponse result = _web_Service.CreateScanReport(SessionID, Report);
		return result;
	}
	[WebMethod()]
	public CxWSReportStatusResponse GetScanReportStatus(string SessionID, long ReportID)
	{
        log.Debug("[CxPortalWebService]- Inside GetScanReportStatus");
		CxWSReportStatusResponse result = _web_Service.GetScanReportStatus(SessionID, ReportID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanResults GetScanReport(string SessionID, long ReportID)
	{
        log.Debug("[CxPortalWebService]- Inside GetScanReport");
		CxWSResponseScanResults result = _web_Service.GetScanReport(SessionID, ReportID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CancelScanReport(string SessionID, long ReportID)
	{
        log.Debug("[CxPortalWebService]- Inside CancelScanReport");
		CxWSBasicRepsonse result = _web_Service.CancelScanReport(SessionID, ReportID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse SaveUserPreferences(string SessionID, CxUserPreferences[] Preferences)
	{
        log.Debug("[CxPortalWebService]- Inside SaveUserPreferences");
		CxWSBasicRepsonse result = _web_Service.SaveUserPreferences(SessionID, Preferences);
		return result;
	}
	[WebMethod()]
	public CxWSUserPreferencesResponse GetUserPreferences(string SessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetUserPreferences");
		CxWSUserPreferencesResponse result = _web_Service.GetUserPreferences(SessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseProjectsScansList GetProjectsWithScans(string sessionId)
	{
        log.Debug("[CxPortalWebService]- Inside GetProjectsWithScans");
		CxWSResponseProjectsScansList result = _web_Service.GetProjectsWithScans(sessionId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseSourceID UploadProjectWithDefaultSettings(string sessionId, ProjectBasicSettings projectSettings, LocalCodeContainer localCodeContainer)
	{
        log.Debug("[CxPortalWebService]- Inside UploadProjectWithDefaultSettings");
		CxWSResponseSourceID result = _web_Service.UploadProjectWithDefaultSettings(sessionId, projectSettings, localCodeContainer);
		return result;
	}
	[WebMethod()]
	public CxWSResponseSourceContainer GetSourceCodeForScan(long scanId)
	{
        log.Debug("[CxPortalWebService]- Inside GetSourceCodeForScan");
		CxWSResponseSourceContainer result = _web_Service.GetSourceCodeForScan(scanId);
		return result;
	}
	[WebMethod()]
	public CxQueryCollectionResponse GetQueryCollectionForLanguage(string sessionId, int projectType, long projectId)
	{
		log.Debug("[CxPortalWebService]- Inside GetQueryCollectionForLanguage");
		CxQueryCollectionResponse result = _web_Service.GetQueryCollectionForLanguage(sessionId, projectType, projectId);
        new CxTeamMentor().TMFilterFor_CxQueryCollectionResponse(result);
		return result;
	}
	[WebMethod()]
	public CxQueryCollectionResponse GetQueryCollectionForLanguageByTeamId(string sessionId, int projectType, string teamId)
	{
        log.Debug("[CxPortalWebService]- Inside GetQueryCollectionForLanguageByTeamId");
		CxQueryCollectionResponse result = _web_Service.GetQueryCollectionForLanguageByTeamId(sessionId, projectType, teamId);

		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UploadQueries(string sessionId, CxWSQueryGroup[] queries)
	{
        log.Debug("[CxPortalWebService]- Inside UploadQueries");
		CxWSBasicRepsonse result = _web_Service.UploadQueries(sessionId, queries);
		return result;
	}
	[WebMethod()]
	public CxWSResponseBasicScanData AddScanResultsToProject(string sessionId, long projectId, string sourceId, AuditResultsCollection resultsCollection, string comment)
	{
        log.Debug("[CxPortalWebService]- Inside AddScanResultsToProject");
		CxWSResponseBasicScanData result = _web_Service.AddScanResultsToProject(sessionId, projectId, sourceId, resultsCollection, comment);
		return result;
	}
	[WebMethod()]
	public CxWSResponseResultCollection GetResults(string sessionId, long scanId)
	{
		log.Debug("[CxPortalWebService]- Inside GetResults");
		CxWSResponseResultCollection result = _web_Service.GetResults(sessionId, scanId);
        new CxTeamMentor().TMFilterFor_CxWSResponseResultCollection(result);
		return result;
	}
	[WebMethod()]
	public CXWSResponseResultSummary GetResultSummary(string sessionId, long scanId)
	{
        log.Debug("[CxPortalWebService]- Inside GetResultSummary");
		CXWSResponseResultSummary result = _web_Service.GetResultSummary(sessionId, scanId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseCache GetCache(string sessionId, long scanId)
	{
        log.Debug("[CxPortalWebService]- Inside GetCache");
		CxWSResponseCache result = _web_Service.GetCache(sessionId, scanId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseLoginData Login(Credentials applicationCredentials, int lcid)
	{
        log.Debug("[CxPortalWebService]- Inside Login");
		CxWSResponseLoginData result = _web_Service.Login(applicationCredentials, lcid);
		return result;
	}
	[WebMethod()]
	public CxWSResponseLoginData SsoLogin(Credentials encryptedCredentials, int lcid)
	{
        log.Debug("[CxPortalWebService]- Inside SsoLogin");
		CxWSResponseLoginData result = _web_Service.SsoLogin(encryptedCredentials, lcid);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse Logout(string sessionID)
	{
        log.Debug("[CxPortalWebService]- Inside Logout");
		CxWSBasicRepsonse result = _web_Service.Logout(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseLoginData LoginBySID(string sessionID)
	{
        log.Debug("[CxPortalWebService]- Inside LoginBySID");
		CxWSResponseLoginData result = _web_Service.LoginBySID(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseGroupList GetAssociatedGroupsList(string SessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetAssociatedGroupsList");
		CxWSResponseGroupList result = _web_Service.GetAssociatedGroupsList(SessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseConfigSetList GetConfigurationSetList(string SessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetConfigurationSetList");
		CxWSResponseConfigSetList result = _web_Service.GetConfigurationSetList(SessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse IsValidProjectName(string SessionID, string ProjectName, string GroupId)
	{
        log.Debug("[CxPortalWebService]- Inside IsValidProjectName");
		CxWSBasicRepsonse result = _web_Service.IsValidProjectName(SessionID, ProjectName, GroupId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseFileSystemLayer GetSharedFileSystemLayer(string SessionID, string Path, Credentials UserCredentials)
	{
        log.Debug("[CxPortalWebService]- Inside GetSharedFileSystemLayer");
		CxWSResponseFileSystemLayer result = _web_Service.GetSharedFileSystemLayer(SessionID, Path, UserCredentials);
		return result;
	}
	[WebMethod()]
	public CxWSResponseFileSystemLayer GetRepositoryFileSystemLayer(string SessionID, string Path, SourceControlSettings SourceControlSettings)
	{
        log.Debug("[CxPortalWebService]- Inside GetRepositoryFileSystemLayer");
		CxWSResponseFileSystemLayer result = _web_Service.GetRepositoryFileSystemLayer(SessionID, Path, SourceControlSettings);
		return result;
	}
	[WebMethod()]
	public CxWSResponseSourceActionList GetSourceControlActionList(string SessionID, string teamId)
	{
        log.Debug("[CxPortalWebService]- Inside GetSourceControlActionList");
		CxWSResponseSourceActionList result = _web_Service.GetSourceControlActionList(SessionID, teamId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseSourceActionList GetPostScanActionList(string SessionID, string teamId)
	{
        log.Debug("[CxPortalWebService]- Inside GetPostScanActionList");
		CxWSResponseSourceActionList result = _web_Service.GetPostScanActionList(SessionID, teamId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseRunID CreateNewProject(string SessionID, ProjectConfiguration Project)
	{
        log.Debug("[CxPortalWebService]- Inside CreateNewProject");
		CxWSResponseRunID result = _web_Service.CreateNewProject(SessionID, Project);
		return result;
	}
	[WebMethod()]
	public CxWSResponseRunID CreateAndRunProject(string SessionID, ProjectSettings ProjectSettings, LocalCodeContainer LocalCodeContainer, bool visibleToOtherUsers)
	{
        log.Debug("[CxPortalWebService]- Inside CreateAndRunProject");
		CxWSResponseRunID result = _web_Service.CreateAndRunProject(SessionID, ProjectSettings, LocalCodeContainer, visibleToOtherUsers);
		return result;
	}
	[WebMethod()]
	public CxWSResponseRunID RunScanAndAddToProject(string sessionId, ProjectSettings projectSettings, LocalCodeContainer localCodeContainer, bool visibleToUtherUsers)
	{
        log.Debug("[CxPortalWebService]- Inside RunScanAndAddToProject");
		CxWSResponseRunID result = _web_Service.RunScanAndAddToProject(sessionId, projectSettings, localCodeContainer, visibleToUtherUsers);
		return result;
	}
	[WebMethod()]
	public CxWSResponseCountLines CountLines(string sessionId, LocalCodeContainer localCodeContainer)
	{
        log.Debug("[CxPortalWebService]- Inside CountLines");
		CxWSResponseCountLines result = _web_Service.CountLines(sessionId, localCodeContainer);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanStatusArray GetScansStatuses(string sessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetScansStatuses");
		CxWSResponseScanStatusArray result = _web_Service.GetScansStatuses(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanStatus GetStatusOfSingleScan(string sessionID, string runId)
	{
        log.Debug("[CxPortalWebService]- Inside GetStatusOfSingleScan");
		CxWSResponseScanStatus result = _web_Service.GetStatusOfSingleScan(sessionID, runId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseQueueRunID PostponeScan(string sessionID, string RunId)
	{
        log.Debug("[CxPortalWebService]- Inside PostponeScan");
		CxWSResponseQueueRunID result = _web_Service.PostponeScan(sessionID, RunId);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CancelScan(string sessionID, string RunId)
	{
        log.Debug("[CxPortalWebService]- Inside CancelScan");
		CxWSBasicRepsonse result = _web_Service.CancelScan(sessionID, RunId);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateProjectUserCredentials(string sessionID, long projectID, Credentials credentials)
	{
        log.Debug("[CxPortalWebService]- Inside UpdateProjectUserCredentials");
		CxWSBasicRepsonse result = _web_Service.UpdateProjectUserCredentials(sessionID, projectID, credentials);
		return result;
	}
	[WebMethod()]
	public CxWSResponseProjectsData GetProjectsWithUserCredentials(string sessionID, string username)
	{
        log.Debug("[CxPortalWebService]- Inside GetProjectsWithUserCredentials");
		CxWSResponseProjectsData result = _web_Service.GetProjectsWithUserCredentials(sessionID, username);
		return result;
	}
	[WebMethod()]
	public CxWSResponseNameList GetProjectsCredentialUsers(string sessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetProjectsCredentialUsers");
		CxWSResponseNameList result = _web_Service.GetProjectsCredentialUsers(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseProjectsDisplayData GetProjectsDisplayData(string sessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetProjectsDisplayData");
		CxWSResponseProjectsDisplayData result = _web_Service.GetProjectsDisplayData(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse RunProjectImmediately(string sessionID, long projectID)
	{
        log.Debug("[CxPortalWebService]- Inside RunProjectImmediately");
		CxWSBasicRepsonse result = _web_Service.RunProjectImmediately(sessionID, projectID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse RunProjectIncrementally(string sessionID, long projectID)
	{
        log.Debug("[CxPortalWebService]- Inside RunProjectIncrementally");
		CxWSBasicRepsonse result = _web_Service.RunProjectIncrementally(sessionID, projectID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse DeleteProject(string sessionID, long projectID)
	{
        log.Debug("[CxPortalWebService]- Inside DeleteProject");
		CxWSBasicRepsonse result = _web_Service.DeleteProject(sessionID, projectID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseProjectConfig GetProjectConfiguration(string sessionID, long projectID)
	{
        log.Debug("[CxPortalWebService]- Inside GetProjectConfiguration");
		CxWSResponseProjectConfig result = _web_Service.GetProjectConfiguration(sessionID, projectID);
		return result;
	}
	[WebMethod()]
	public CxWSResponsProjectProperties GetProjectProperties(string sessionID, long projectID, ScanType scanType)
	{
        log.Debug("[CxPortalWebService]- Inside GetProjectProperties");
		CxWSResponsProjectProperties result = _web_Service.GetProjectProperties(sessionID, projectID, scanType);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateProjectConfiguration(string sessionID, long projectID, ProjectConfiguration projectConfiguration)
	{
        log.Debug("[CxPortalWebService]- Inside UpdateProjectConfiguration");
		CxWSBasicRepsonse result = _web_Service.UpdateProjectConfiguration(sessionID, projectID, projectConfiguration);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateProjectIncrementalConfiguration(string sessionID, long projectID, ProjectConfiguration projectConfiguration)
	{
        log.Debug("[CxPortalWebService]- Inside UpdateProjectConfiguration");
		CxWSBasicRepsonse result = _web_Service.UpdateProjectIncrementalConfiguration(sessionID, projectID, projectConfiguration);
		return result;
	}
	[WebMethod()]
	public CxWSResponsProjectChartData GetProjectCharts(string sessionID, long projectID, ScanType scanType)
	{
        log.Debug("[CxPortalWebService]- Inside GetProjectCharts");
		CxWSResponsProjectChartData result = _web_Service.GetProjectCharts(sessionID, projectID, scanType);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse ResetIgnorePath(string sessionID, long ProjectId)
	{
        log.Debug("[CxPortalWebService]- Inside ResetIgnorePath");
		CxWSBasicRepsonse result = _web_Service.ResetIgnorePath(sessionID, ProjectId);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse SetFalsePositiveFlag(string sessionID, long ResultId, long PathId, long projectId, bool falsePositiveFlag)
	{
        log.Debug("[CxPortalWebService]- Inside SetFalsePositiveFlag");
		CxWSBasicRepsonse result = _web_Service.SetFalsePositiveFlag(sessionID, ResultId, PathId, projectId, falsePositiveFlag);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateResultComment(string sessionID, long ResultId, long PathId, long projectId, string comment)
	{
        log.Debug("[CxPortalWebService]- Inside UpdateResultComment");
		CxWSBasicRepsonse result = _web_Service.UpdateResultComment(sessionID, ResultId, PathId, projectId, comment);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateResultState(string sessionID, long scanId, long PathId, long projectId, string Remarks, int ResultLabelType, string data)
	{
        log.Debug("[CxPortalWebService]- Inside UpdateResultState");
		CxWSBasicRepsonse result = _web_Service.UpdateResultState(sessionID, scanId, PathId, projectId, Remarks, ResultLabelType, data);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateSetOfResultState(string sessionID, ResultStateData[] resultsStates)
	{
        log.Debug("[CxPortalWebService]- Inside UpdateSetOfResultState");
		CxWSBasicRepsonse result = _web_Service.UpdateSetOfResultState(sessionID, resultsStates);
		return result;
	}
	[WebMethod()]
	public CxWSResponseRunID RunScanWithExistingProject(string sessionId, string projectName)
	{
        log.Debug("[CxPortalWebService]- Inside RunScanWithExistingProject");
		CxWSResponseRunID result = _web_Service.RunScanWithExistingProject(sessionId, projectName);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScansDisplayData GetScansDisplayData(string sessionID, long projectID)
	{
        log.Debug("[CxPortalWebService]- Inside GetScansDisplayData");
		CxWSResponseScansDisplayData result = _web_Service.GetScansDisplayData(sessionID, projectID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse DeleteScan(string sessionID, long ScanID)
	{
        log.Debug("[CxPortalWebService]- Inside DeleteScan");
		CxWSBasicRepsonse result = _web_Service.DeleteScan(sessionID, ScanID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanProperties GetScanProperties(string sessionID, long ScanID)
	{
        log.Debug("[CxPortalWebService]- Inside GetScanProperties");
		CxWSResponseScanProperties result = _web_Service.GetScanProperties(sessionID, ScanID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateScanComment(string sessionID, long ScanID, string Comment)
	{
        log.Debug("[CxPortalWebService]- Inside UpdateScanComment");
		CxWSBasicRepsonse result = _web_Service.UpdateScanComment(sessionID, ScanID, Comment);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScansDisplayData GetScansDisplayDataForAllProjects(string sessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetScansDisplayDataForAllProjects");
		CxWSResponseScansDisplayData result = _web_Service.GetScansDisplayDataForAllProjects(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanSummary GetScanSummary(string i_SessionID, long i_ScanID)
	{
        log.Debug("[CxPortalWebService]- Inside GetScanSummary");
		CxWSResponseScanSummary result = _web_Service.GetScanSummary(i_SessionID, i_ScanID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanCompareSummary GetScanCompareSummary(string sessionId, long oldScanId, long newScanId)
	{
        log.Debug("[CxPortalWebService]- Inside GetScanCompareSummary");
		CxWSResponseScanCompareSummary result = _web_Service.GetScanCompareSummary(sessionId, oldScanId, newScanId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanCompareReport GetScanCompareReport(string sessionId, long oldScanId, long newScanId)
	{
        log.Debug("[CxPortalWebService]- Inside GetScanCompareReport");
		CxWSResponseScanCompareReport result = _web_Service.GetScanCompareReport(sessionId, oldScanId, newScanId);
		return result;
	}
	[WebMethod()]
	public CxWSResponceScanCompareResults GetCompareScanResults(string sessionId, long oldScanId, long newScanId)
	{
        log.Debug("[CxPortalWebService]- Inside GetCompareScanResults");
		CxWSResponceScanCompareResults result = _web_Service.GetCompareScanResults(sessionId, oldScanId, newScanId);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CreateScanPDFReport(string sessionID, long scanID)
	{
        log.Debug("[CxPortalWebService]- Inside CreateScanPDFReport");
		CxWSBasicRepsonse result = _web_Service.CreateScanPDFReport(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CreateScannedFilesReport(string sessionID, long scanID)
	{
        log.Debug("[CxPortalWebService]- Inside CreateScannedFilesReport");
		CxWSBasicRepsonse result = _web_Service.CreateScannedFilesReport(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CXWSResponseScanReportStatus GetScanPDFReportStatus(string sessionID, long scanID)
	{
        log.Debug("[CxPortalWebService]- Inside CreateScannedFilesReport");
		CXWSResponseScanReportStatus result = _web_Service.GetScanPDFReportStatus(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CXWSResponseScanReportStatus GetScannedFilesReportStatus(string sessionID, long scanID)
	{
        log.Debug("[CxPortalWebService]- Inside CreateScannedFilesReport");
		CXWSResponseScanReportStatus result = _web_Service.GetScannedFilesReportStatus(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanResults GetScanPDFReport(string sessionID, long scanID)
	{
        log.Debug("[CxPortalWebService]- Inside CreateScannedFilesReport");
		CxWSResponseScanResults result = _web_Service.GetScanPDFReport(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanResults GetScannedFilesReport(string sessionID, long scanID)
	{
        log.Debug("[CxPortalWebService]- Inside CreateScannedFilesReport");
		CxWSResponseScanResults result = _web_Service.GetScannedFilesReport(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CreateScanExcelReport(string sessionID, long scanID)
	{
        log.Debug("[CxPortalWebService]- Inside CreateScanExcelReport");
		CxWSBasicRepsonse result = _web_Service.CreateScanExcelReport(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CXWSResponseScanReportStatus GetScanExcelReportStatus(string sessionID, long scanID)
	{
        log.Debug("[CxPortalWebService]- Inside GetScanExcelReportStatus");
		CXWSResponseScanReportStatus result = _web_Service.GetScanExcelReportStatus(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanResults GetScanExcelReport(string sessionID, long scanID)
	{
        log.Debug("[CxPortalWebService]- Inside GetScanExcelReport");
		CxWSResponseScanResults result = _web_Service.GetScanExcelReport(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CreateScanXMLReport(string sessionID, long scanID)
	{
        log.Debug("[CxPortalWebService]- Inside CreateScanXMLReport");
		CxWSBasicRepsonse result = _web_Service.CreateScanXMLReport(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CXWSResponseScanReportStatus GetScanXMLReportStatus(string sessionID, long scanID)
	{
        log.Debug("[CxPortalWebService]- Inside GetScanXMLReportStatus");
		CXWSResponseScanReportStatus result = _web_Service.GetScanXMLReportStatus(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanResults GetScanXMLReport(string sessionID, long scanID)
	{
        log.Debug("[CxPortalWebService]- Inside GetScanXMLReport");
		CxWSResponseScanResults result = _web_Service.GetScanXMLReport(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanResults GetScanXMLReportByRunId(string sessionID, string runId)
	{
		log.Debug("[CxPortalWebService]- Inside GetScanXMLReportByRunId");
		CxWSResponseScanResults result = _web_Service.GetScanXMLReportByRunId(sessionID, runId);
        if (result.ScanResults != null)
        {
            new CxTeamMentor().TMFilterFor_CxWSResponseScanResults(result);
        }
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanResults GetScanPDFReportByRunId(string sessionID, string runId)
	{
        log.Debug("[CxPortalWebService]- Inside GetScanPDFReportByRunId");
		CxWSResponseScanResults result = _web_Service.GetScanPDFReportByRunId(sessionID, runId);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CreateScanRTFReport(string sessionID, long scanID)
	{
        log.Debug("[CxPortalWebService]- Inside CreateScanRTFReport");
		CxWSBasicRepsonse result = _web_Service.CreateScanRTFReport(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CXWSResponseScanReportStatus GetScanRTFReportStatus(string sessionID, long scanID)
	{
        log.Debug("[CxPortalWebService]- Inside GetScanRTFReportStatus");
		CXWSResponseScanReportStatus result = _web_Service.GetScanRTFReportStatus(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanResults GetScanRTFReport(string sessionID, long scanID)
	{
        log.Debug("[CxPortalWebService]- Inside GetScanRTFReport");
		CxWSResponseScanResults result = _web_Service.GetScanRTFReport(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseQueryDescription GetQueryDescription(string sessionId, int cweId)
	{
		log.Debug("[CxPortalWebService]- Inside GetQueryDescription");
		CxWSResponseQueryDescription result = _web_Service.GetQueryDescription(sessionId, cweId);
		result.IsSuccesfull = true;
        result.ErrorMessage = string.Empty;
        new CxTeamMentor().TMFilterFor_CxWSResponseQueryDescription(cweId, result);
		return result;
	}
	[WebMethod()]
	public CxWSResponseSourceContent GetSourceByScanID(string sessionID, long scanID, string fileToRetreive)
	{
        log.Debug("[CxPortalWebService]- Inside GetSourceByScanID");
		CxWSResponseSourceContent result = _web_Service.GetSourceByScanID(sessionID, scanID, fileToRetreive);
		return result;
	}
	[WebMethod()]
	public CxWSResponseResultStateList GetResultStateList(string sessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetResultStateList");
		CxWSResponseResultStateList result = _web_Service.GetResultStateList(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseBool IsSMTPHostConfigured()
	{
        log.Debug("[CxPortalWebService]- Inside IsSMTPHostConfigured");
		CxWSResponseBool result = _web_Service.IsSMTPHostConfigured();
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse IsAdminAllowedToChangeUserPassword(string sessionID, long userID)
	{
        log.Debug("[CxPortalWebService]- Inside IsAdminAllowedToChangeUserPassword");
		CxWSBasicRepsonse result = _web_Service.IsAdminAllowedToChangeUserPassword(sessionID, userID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse ForgotPassword(string passwordChangePageUrl, string userName, string email)
	{
        log.Debug("[CxPortalWebService]- Inside ForgotPassword");
		CxWSBasicRepsonse result = _web_Service.ForgotPassword(passwordChangePageUrl, userName, email);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse ResetPassword(string sessionID, string loginUrl, long userID)
	{
        log.Debug("[CxPortalWebService]- Inside ResetPassword");
		CxWSBasicRepsonse result = _web_Service.ResetPassword(sessionID, loginUrl, userID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CheckChangePasswordToken(string token)
	{
        log.Debug("[CxPortalWebService]- Inside CheckChangePasswordToken");
		CxWSBasicRepsonse result = _web_Service.CheckChangePasswordToken(token);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse ChangePasswordWithToken(string token, string password)
	{
        log.Debug("[CxPortalWebService]- Inside ChangePasswordWithToken");
		CxWSBasicRepsonse result = _web_Service.ChangePasswordWithToken(token, password);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse ChangePassword(string sessionID, string oldPsw, string newPsw)
	{
        log.Debug("[CxPortalWebService]- Inside ChangePassword");
		CxWSBasicRepsonse result = _web_Service.ChangePassword(sessionID, oldPsw, newPsw);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse ChangePasswordAdminToUser(string sessionID, long userID, string newPassword)
	{
        log.Debug("[CxPortalWebService]- Inside ChangePasswordAdminToUser");
		CxWSBasicRepsonse result = _web_Service.ChangePasswordAdminToUser(sessionID, userID, newPassword);
		return result;
	}
	[WebMethod()]
	public CxWSResponseGroupList GetCompanies()
	{
        log.Debug("[CxPortalWebService]- Inside GetCompanies");
		CxWSResponseGroupList result = _web_Service.GetCompanies();
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse RegisterPendingUser(WebClientPendingUser pendingUser, string pendingUsersTableUrl)
	{
        log.Debug("[CxPortalWebService]- Inside RegisterPendingUser");
		CxWSBasicRepsonse result = _web_Service.RegisterPendingUser(pendingUser, pendingUsersTableUrl);
		return result;
	}
	[WebMethod()]
	public CxWSResponsePendingUsersList GetPendingUsersList(string sessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetPendingUsersList");
		CxWSResponsePendingUsersList result = _web_Service.GetPendingUsersList(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse DeletePendingUsers(string sessionID, int[] userIdList)
	{
        log.Debug("[CxPortalWebService]- Inside DeletePendingUsers");
		CxWSBasicRepsonse result = _web_Service.DeletePendingUsers(sessionID, userIdList);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse ApprovePendingUsers(string sessionID, WebClientApprovedUser[] userList)
	{
        log.Debug("[CxPortalWebService]- Inside ApprovePendingUsers");
		CxWSBasicRepsonse result = _web_Service.ApprovePendingUsers(sessionID, userList);
		return result;
	}
	[WebMethod()]
	public CxWSResponseProfileData GetUserProfileData(string sessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetUserProfileData");
		CxWSResponseProfileData result = _web_Service.GetUserProfileData(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateUserProfileData(string sessionID, ProfileData userProfileData)
	{
        log.Debug("[CxPortalWebService]- Inside UpdateUserProfileData");
		CxWSBasicRepsonse result = _web_Service.UpdateUserProfileData(sessionID, userProfileData);
		return result;
	}
	[WebMethod()]
	public CxWSResponseUserData GetAllUsers(string sessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetAllUsers");
		CxWSResponseUserData result = _web_Service.GetAllUsers(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseUserData GetAllUsersInGroup(string sessionID, string groupID, bool isRecursive)
	{
        log.Debug("[CxPortalWebService]- Inside GetAllUsersInGroup");
		CxWSResponseUserData result = _web_Service.GetAllUsersInGroup(sessionID, groupID, isRecursive);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse DeleteUser(string sessionID, int userID)
	{
        log.Debug("[CxPortalWebService]- Inside DeleteUser");
		CxWSBasicRepsonse result = _web_Service.DeleteUser(sessionID, userID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseHierarchyGroupNodes GetHierarchyGroupTree(string sessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetHierarchyGroupTree");
		CxWSResponseHierarchyGroupNodes result = _web_Service.GetHierarchyGroupTree(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseHierarchyGroupNodes GetAncestryGroupTree(string sessionID, string pTeamID)
	{
        log.Debug("[CxPortalWebService]- Inside GetHierarchyGroupTree");
		CxWSResponseHierarchyGroupNodes result = _web_Service.GetAncestryGroupTree(sessionID, pTeamID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse SetUserActivationState(string sessionID, int userID, bool activationState)
	{
        log.Debug("[CxPortalWebService]- Inside SetUserActivationState");
		CxWSBasicRepsonse result = _web_Service.SetUserActivationState(sessionID, userID, activationState);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse AddNewUser(string sessionID, UserData userData, CxUserTypes userType)
	{
        log.Debug("[CxPortalWebService]- Inside AddNewUser");
		CxWSBasicRepsonse result = _web_Service.AddNewUser(sessionID, userData, userType);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateUserData(string sessionID, UserData userData)
	{
        log.Debug("[CxPortalWebService]- Inside UpdateUserData");
		CxWSBasicRepsonse result = _web_Service.UpdateUserData(sessionID, userData);
		return result;
	}
	[WebMethod()]
	public CxWSResponseServerLicenseData GetServerLicenseData(string sessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetServerLicenseData");
		CxWSResponseServerLicenseData result = _web_Service.GetServerLicenseData(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseUsersLicenseData GetUsersLicenseData(string sessionID, string groupID)
	{
        log.Debug("[CxPortalWebService]- Inside GetUsersLicenseData");
		CxWSResponseUsersLicenseData result = _web_Service.GetUsersLicenseData(sessionID, groupID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseCompaniesLicenseData GetCompaniesLicenseData(string sessionID, string groupID)
	{
        log.Debug("[CxPortalWebService]- Inside GetCompaniesLicenseData");
		CxWSResponseCompaniesLicenseData result = _web_Service.GetCompaniesLicenseData(sessionID, groupID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseSPLicenseData GetSPLicenseData(string sessionID, string groupID)
	{
        log.Debug("[CxPortalWebService]- Inside GetSPLicenseData");
		CxWSResponseSPLicenseData result = _web_Service.GetSPLicenseData(sessionID, groupID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateUserGroups(string sessionID, long userID, Group[] unsubscribedGroups, Group[] subscribedGroups, Role role)
	{
        log.Debug("[CxPortalWebService]- Inside UpdateUserGroups");
		CxWSBasicRepsonse result = _web_Service.UpdateUserGroups(sessionID, userID, unsubscribedGroups, subscribedGroups, role);
		return result;
	}
	[WebMethod()]
	public CxWSResponseGroupList GetCompaniesList()
	{
        log.Debug("[CxPortalWebService]- Inside GetCompaniesList");
		CxWSResponseGroupList result = _web_Service.GetCompaniesList();
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse IsValidUserName(string sessionID, string username)
	{
        log.Debug("[CxPortalWebService]- Inside IsValidUserName");
		CxWSBasicRepsonse result = _web_Service.IsValidUserName(sessionID, username);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse IsValidEmail(string email)
	{
        log.Debug("[CxPortalWebService]- Inside IsValidEmail");
		CxWSBasicRepsonse result = _web_Service.IsValidEmail(email);
		return result;
	}
	[WebMethod()]
	public CxWSResponseNameList GetAvailbleDomainNames(string sessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetAvailbleDomainNames");
		CxWSResponseNameList result = _web_Service.GetAvailbleDomainNames(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseDomainUserList GetAllUsersFromDomain(string sessionID, string domain, string i_SearchPattern)
	{
        log.Debug("[CxPortalWebService]- Inside GetAllUsersFromDomain");
		CxWSResponseDomainUserList result = _web_Service.GetAllUsersFromDomain(sessionID, domain, i_SearchPattern);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CreateNewTeam(string sessionID, string parentTeamID, string newTeamName)
	{
        log.Debug("[CxPortalWebService]- Inside CreateNewTeam");
		CxWSBasicRepsonse result = _web_Service.CreateNewTeam(sessionID, parentTeamID, newTeamName);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse RenameTeam(string sessionID, string teamID, string newTeamName)
	{
        log.Debug("[CxPortalWebService]- Inside RenameTeam");
		CxWSBasicRepsonse result = _web_Service.RenameTeam(sessionID, teamID, newTeamName);
		return result;
	}
	[WebMethod()]
	public CxWSResponseTeamData GetAllTeams(string sessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetAllTeams");
		CxWSResponseTeamData result = _web_Service.GetAllTeams(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse DeleteTeam(string sessionID, string teamID)
	{
        log.Debug("[CxPortalWebService]- Inside DeleteTeam");
		CxWSBasicRepsonse result = _web_Service.DeleteTeam(sessionID, teamID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CreateNewCompany(string sessionID, string ParentSP, string newTCompanyName, int companyManagers, int scanners, int reviewers, bool allowActions)
	{
        log.Debug("[CxPortalWebService]- Inside CreateNewCompany");
		CxWSBasicRepsonse result = _web_Service.CreateNewCompany(sessionID, ParentSP, newTCompanyName, companyManagers, scanners, reviewers, allowActions);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CreateNewServiceProvider(string sessionID, string newSpName, int spManagersint, int companyManagers, int scanners, int reviewers)
	{
        log.Debug("[CxPortalWebService]- Inside CreateNewServiceProvider");
		CxWSBasicRepsonse result = _web_Service.CreateNewServiceProvider(sessionID, newSpName, spManagersint, companyManagers, scanners, reviewers);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse RenameCompany(string sessionID, string teamID, string newTeamName)
	{
        log.Debug("[CxPortalWebService]- Inside RenameCompany");
		CxWSBasicRepsonse result = _web_Service.RenameCompany(sessionID, teamID, newTeamName);
		return result;
	}
	[WebMethod()]
	public CxWSResponseTeamData GetAllCompanies(string sessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetAllCompanies");
		CxWSResponseTeamData result = _web_Service.GetAllCompanies(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseTeamData GetAllSPs(string sessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetAllSPs");
		CxWSResponseTeamData result = _web_Service.GetAllSPs(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse DeleteCompany(string sessionID, string teamID)
	{
        log.Debug("[CxPortalWebService]- Inside DeleteCompany");
		CxWSBasicRepsonse result = _web_Service.DeleteCompany(sessionID, teamID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse DeleteSP(string sessionID, string teamID)
	{
        log.Debug("[CxPortalWebService]- Inside DeleteSP");
		CxWSBasicRepsonse result = _web_Service.DeleteSP(sessionID, teamID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse IsValidCompanyName(string sessionID, string companyName, string serviceProviderID)
	{
        log.Debug("[CxPortalWebService]- Inside IsValidCompanyName");
		CxWSBasicRepsonse result = _web_Service.IsValidCompanyName(sessionID, companyName, serviceProviderID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseTeamData GetCompanyTeams(string sessionID, string companyID)
	{
        log.Debug("[CxPortalWebService]- Inside GetCompanyTeams");
		CxWSResponseTeamData result = _web_Service.GetCompanyTeams(sessionID, companyID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseTeamData GetServiceProviderTeams(string sessionID, string spID)
	{
        log.Debug("[CxPortalWebService]- Inside GetServiceProviderTeams");
		CxWSResponseTeamData result = _web_Service.GetServiceProviderTeams(sessionID, spID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseTeamData GetServiceProviderCompanies(string sessionID, string spID)
	{
        log.Debug("[CxPortalWebService]- Inside GetServiceProviderCompanies");
		CxWSResponseTeamData result = _web_Service.GetServiceProviderCompanies(sessionID, spID);
		return result;
	}
	[WebMethod()]
	public CxWsResponseCompanyProperties GetCompanyProperties(string sessionID, string companyID)
	{
        log.Debug("[CxPortalWebService]- Inside GetCompanyProperties");
		CxWsResponseCompanyProperties result = _web_Service.GetCompanyProperties(sessionID, companyID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse SetUserAsCompanyManager(string sessionID, string companyID, long userID)
	{
        log.Debug("[CxPortalWebService]- Inside SetUserAsCompanyManager");
		CxWSBasicRepsonse result = _web_Service.SetUserAsCompanyManager(sessionID, companyID, userID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse SetUserAsServiceProviderManager(string sessionID, string spID, long userID)
	{
        log.Debug("[CxPortalWebService]- Inside SetUserAsServiceProviderManager");
		CxWSBasicRepsonse result = _web_Service.SetUserAsServiceProviderManager(sessionID, spID, userID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse IsValidServiceProviderName(string sessionID, string serviceProviderName)
	{
        log.Debug("[CxPortalWebService]- Inside IsValidServiceProviderName");
		CxWSBasicRepsonse result = _web_Service.IsValidServiceProviderName(sessionID, serviceProviderName);
		return result;
	}
}
}
