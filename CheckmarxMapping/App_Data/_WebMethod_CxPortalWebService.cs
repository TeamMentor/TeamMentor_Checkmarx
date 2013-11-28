//O2File:CxPortalWebService_Proxy.cs
using System.Web.Services;
using System;
using log4net;
using log4net.Config;

[WebService(Namespace = "http://Checkmarx.com/")]
public class CxPortalWebService
{
    private ILog log = LogManager.GetLogger(typeof(CxPortalWebService));
	public CxPortalWebService_Proxy WebServiceProxy { get; set; }
	public CxPortalWebService()
	{
        XmlConfigurator.Configure();

        log.Debug("WebService proxy constructor.Loading user data");
	    var config = new CXConfiguration();
	    var data =config.secretData_Load();

        log.Debug("Checkmarx WebService proxy is " + data.CheckMarx_WebService_EndPoint);
	   
		WebServiceProxy = new CxPortalWebService_Proxy(data.CheckMarx_WebService_EndPoint);
	}
	[WebMethod()]
	public CxWSResponseInstallationSettings GetInstallationSettings(string sessionID)
	{
		CxWSResponseInstallationSettings result = WebServiceProxy.GetInstallationSettings(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponsePresetList GetPresetList(string SessionID)
	{
		CxWSResponsePresetList result = WebServiceProxy.GetPresetList(SessionID);
		return result;
	}
	[WebMethod()]
	public CxQueryCollectionResponse GetQueryCollection(string sessionId)
	{
		CxQueryCollectionResponse result = WebServiceProxy.GetQueryCollection(sessionId);
        
		return result;
	}
	[WebMethod()]
	public CxWSResponsePresetDetails GetPresetDetails(string sessionId, long id)
	{
		CxWSResponsePresetDetails result = WebServiceProxy.GetPresetDetails(sessionId, id);
		return result;
	}
	[WebMethod()]
	public CxWSResponsePresetDetails CreateNewPreset(string sessionId, CxPresetDetails presrt)
	{
		CxWSResponsePresetDetails result = WebServiceProxy.CreateNewPreset(sessionId, presrt);
		return result;
	}
	[WebMethod()]
	public CxWSResponsePresetDetails UpdatePreset(string sessionId, CxPresetDetails presrt)
	{
		CxWSResponsePresetDetails result = WebServiceProxy.UpdatePreset(sessionId, presrt);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse DeletePreset(string sessionId, long id)
	{
		CxWSBasicRepsonse result = WebServiceProxy.DeletePreset(sessionId, id);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse IsValidPresetName(string sessionID, string presetName)
	{
		CxWSBasicRepsonse result = WebServiceProxy.IsValidPresetName(sessionID, presetName);
		return result;
	}
	[WebMethod()]
	public CxWSResponceQuerisForScan GetQueriesForScan(string sessionID, long scanId)
	{
        CxWSResponceQuerisForScan result = WebServiceProxy.GetQueriesForScan(sessionID, scanId);
        log.Debug("[CxPortalWebService]- Inside GetQueriesForScan");
        if (result != null && result.Queries != null)
        {
            new CxTeamMentor().TMFilterFor_CxWSResponceQuerisForScan(result);
        }
        return result;
	}
	[WebMethod()]
	public CxWSResponceQuerisForScanAndId GetQueriesForScanByRunId(string sessionID, string runId)
	{
        log.Debug("[CxPortalWebService]- Inside GetQueriesForScanByRunId");
        CxWSResponceQuerisForScanAndId result = WebServiceProxy.GetQueriesForScanByRunId(sessionID, runId);
        if (result != null && result.Queries != null)
        {
            new CxTeamMentor().TMFilterFor_CxWSResponceQuerisForScanAndId(result);
        }
        return result;
	}
	[WebMethod()]
	public CxWSResponceScanResults GetResultsForQuery(string sessionID, long scanId, long queryId)
    {
        CxWSResponceScanResults result = WebServiceProxy.GetResultsForQuery(sessionID, scanId, queryId);
        //if (result != null && result.Results != null)
        //{
        //    new CxTeamMentor().TMFilterFor_CxWSResponceScanResults(result);
        //}
        return result;
	}
	[WebMethod()]
	public CxWSResponceScanResults GetResultsForQueryQroup(string sessionID, long scanId, long queryGroupId)
	{
        log.Debug("[CxPortalWebService]- Inside GetResultsForQueryQroup");
		CxWSResponceScanResults result = WebServiceProxy.GetResultsForQueryQroup(sessionID, scanId, queryGroupId);
		return result;
	}
	[WebMethod()]
	public CxWSResponceScanResults GetResultsForScan(string sessionID, long scanId)
	{
        log.Debug("[CxPortalWebService]- Inside GetResultsForScan");
		CxWSResponceScanResults result = WebServiceProxy.GetResultsForScan(sessionID, scanId);
         //new CxTeamMentor().TMFilterFor_CxWSResponceScanResults(result);
		return result;
	}
	[WebMethod()]
	public CxWSResponceResultPath GetResultPath(string sessionId, long scanId, long pathId)
	{
        log.Debug("[CxPortalWebService]- Inside GetResultPath");
		CxWSResponceResultPath result = WebServiceProxy.GetResultPath(sessionId, scanId, pathId);
		return result;
	}
	[WebMethod()]
	public CxWSResponceFileNames GetFileNamesForPath(string sessionId, long scanId, long pathId)
	{
        log.Debug("[CxPortalWebService]- Inside GetFileNamesForPath");
		CxWSResponceFileNames result = WebServiceProxy.GetFileNamesForPath(sessionId, scanId, pathId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseResultPaths GetResultPathsForQuery(string sessionId, long scanId, long queryId)
	{
        log.Debug("[CxPortalWebService]- Inside GetResultPathsForQuery");
		CxWSResponseResultPaths result = WebServiceProxy.GetResultPathsForQuery(sessionId, scanId, queryId);
		return result;
	}
	[WebMethod()]
	public CxWSResponceScanResults GetResultsBySeverity(string sessionId, long scanId, int Severity)
	{
        log.Debug("[CxPortalWebService]- Inside GetResultsBySeverity");
		CxWSResponceScanResults result = WebServiceProxy.GetResultsBySeverity(sessionId, scanId, Severity);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse SavePredefinedCommands(string sessionID, CxPredefinedCommand[] predefinedCommands)
	{
        log.Debug("[CxPortalWebService]- Inside GetResultsBySeverity");
		CxWSBasicRepsonse result = WebServiceProxy.SavePredefinedCommands(sessionID, predefinedCommands);
		return result;
	}
	[WebMethod()]
	public CxWSResponsePredefinedCommands GetPredefinedCommands(string sessionId)
	{
		CxWSResponsePredefinedCommands result = WebServiceProxy.GetPredefinedCommands(sessionId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseNameList GetExecutableList(string sessionId)
	{
        log.Debug("[CxPortalWebService]- Inside GetExecutableList");
		CxWSResponseNameList result = WebServiceProxy.GetExecutableList(sessionId);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdatePermission(string sessionID, CxPermission permission, string teamId)
	{
		CxWSBasicRepsonse result = WebServiceProxy.UpdatePermission(sessionID, permission, teamId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseUserData GetProjectAssignUsers(string sessionID, long projectId)
	{
        log.Debug("[CxPortalWebService]- Inside GetProjectAssignUsers");
		CxWSResponseUserData result = WebServiceProxy.GetProjectAssignUsers(sessionID, projectId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseBool IsAllowAutoSignIn()
	{
		CxWSResponseBool result = WebServiceProxy.IsAllowAutoSignIn();
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse SaveSubsetResults(string sessionId, long projectId, long ScanId, long[] pathIds, string comments)
	{
		CxWSBasicRepsonse result = WebServiceProxy.SaveSubsetResults(sessionId, projectId, ScanId, pathIds, comments);
		return result;
	}
	[WebMethod()]
	public CxWSResponsePivotTable GetPivotData(string SessionID, CxPivotDataRequest PivotParams)
	{
        log.Debug("[CxPortalWebService]- Inside GetPivotData");
		CxWSResponsePivotTable result = WebServiceProxy.GetPivotData(SessionID, PivotParams);
		return result;
	}
	[WebMethod()]
	public CxWSResponsePivotLayouts GetPivotLayouts(string SessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetPivotLayouts");
		CxWSResponsePivotLayouts result = WebServiceProxy.GetPivotLayouts(SessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse SavePivotLayout(string SessionID, CxPivotLayout layout)
	{
		CxWSBasicRepsonse result = WebServiceProxy.SavePivotLayout(SessionID, layout);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse DeletePivotLayout(string SessionID, long LayoutID)
	{
		CxWSBasicRepsonse result = WebServiceProxy.DeletePivotLayout(SessionID, LayoutID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseShortQueryDescription GetQueryShortDescription(string sessionId, long queryId)
	{
		CxWSResponseShortQueryDescription result = WebServiceProxy.GetQueryShortDescription(sessionId, queryId);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse RegisterSaasPendingUser(SaasPendingUser pendingUser, string activationPageUrl)
	{
		CxWSBasicRepsonse result = WebServiceProxy.RegisterSaasPendingUser(pendingUser, activationPageUrl);
		return result;
	}
	[WebMethod()]
	public CxWSResponseSaasLoginData ActivateSaasUser(string userToken)
	{
		CxWSResponseSaasLoginData result = WebServiceProxy.ActivateSaasUser(userToken);
		return result;
	}
	[WebMethod()]
	public CxWSResponseSaasPackage GetSaasPackages()
	{
		CxWSResponseSaasPackage result = WebServiceProxy.GetSaasPackages();
		return result;
	}
	[WebMethod()]
	public CxWSResponseSaasPackage GetTeamSaaSPackage(string teamId)
	{
		CxWSResponseSaasPackage result = WebServiceProxy.GetTeamSaaSPackage(teamId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseSaasLoginData SaasLogin(Credentials applicationCredentials, int lcid)
	{
		CxWSResponseSaasLoginData result = WebServiceProxy.SaasLogin(applicationCredentials, lcid);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse SendEmailForSales(string sessionID, EmailForSalesData emailData)
	{
		CxWSBasicRepsonse result = WebServiceProxy.SendEmailForSales(sessionID, emailData);
		return result;
	}
	[WebMethod()]
	public CxWSResponseEngineServers GetEngineServers(string sessionID)
	{
		CxWSResponseEngineServers result = WebServiceProxy.GetEngineServers(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateEngineServer(string sessionID, CxEngineServer engine)
	{
		CxWSBasicRepsonse result = WebServiceProxy.UpdateEngineServer(sessionID, engine);
		return result;
	}
	[WebMethod()]
	public CxWSResponseEngineServerId CreateEngineServer(string sessionID, CxEngineServer engine)
	{
		CxWSResponseEngineServerId result = WebServiceProxy.CreateEngineServer(sessionID, engine);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse DeleteEngineServer(string sessionID, long id)
	{
		CxWSBasicRepsonse result = WebServiceProxy.DeleteEngineServer(sessionID, id);
		return result;
	}
	[WebMethod()]
	public CxWSResponseRunID Scan(string sessionId, CliScanArgs args)
	{
        log.Debug("[CxPortalWebService]- Inside Scan");
		CxWSResponseRunID result = WebServiceProxy.Scan(sessionId, args);
		return result;
	}
	[WebMethod()]
	public CxWSResponseQueries ExportQueries(string sessionId, long[] queryIds)
	{
		CxWSResponseQueries result = WebServiceProxy.ExportQueries(sessionId, queryIds);
		return result;
	}
	[WebMethod()]
	public CxWSResponsePreset ExportPreset(string sessionId, long presetId)
	{
		CxWSResponsePreset result = WebServiceProxy.ExportPreset(sessionId, presetId);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse ImportQueries(string sessionId, 	[System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
byte[] importedFile)
	{
		CxWSBasicRepsonse result = WebServiceProxy.ImportQueries(sessionId, importedFile);
		return result;
	}
	[WebMethod()]
	public CxWSResponseTransportedQueries GetExistingQueries(string sessionId, 	[System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
byte[] importedFile)
	{
		CxWSResponseTransportedQueries result = WebServiceProxy.GetExistingQueries(sessionId, importedFile);
		return result;
	}
	[WebMethod()]
	public CxWSResponseExistsingTransportedPresetQueries GetExistingPresetQueries(string sessionId, 	[System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
byte[] importedFile)
	{
		CxWSResponseExistsingTransportedPresetQueries result = WebServiceProxy.GetExistingPresetQueries(sessionId, importedFile);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse ImportPreset(string sessionId, 	[System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
byte[] importedFile)
	{
		CxWSBasicRepsonse result = WebServiceProxy.ImportPreset(sessionId, importedFile);
		return result;
	}
	[WebMethod()]
	public CxWSCreateReportResponse CreateScanReport(string SessionID, CxWSReport Report)
	{
		CxWSCreateReportResponse result = WebServiceProxy.CreateScanReport(SessionID, Report);
		return result;
	}
	[WebMethod()]
	public CxWSReportStatusResponse GetScanReportStatus(string SessionID, long ReportID)
	{
		CxWSReportStatusResponse result = WebServiceProxy.GetScanReportStatus(SessionID, ReportID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanResults GetScanReport(string SessionID, long ReportID)
	{
		CxWSResponseScanResults result = WebServiceProxy.GetScanReport(SessionID, ReportID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse SaveUserPreferences(string SessionID, CxUserPreferences[] Preferences)
	{
		CxWSBasicRepsonse result = WebServiceProxy.SaveUserPreferences(SessionID, Preferences);
		return result;
	}
	[WebMethod()]
	public CxWSUserPreferencesResponse GetUserPreferences(string SessionID)
	{
		CxWSUserPreferencesResponse result = WebServiceProxy.GetUserPreferences(SessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseProjectsScansList GetProjectsWithScans(string sessionId)
	{
        log.Debug("[CxPortalWebService]- Inside GetProjectsWithScans");
		CxWSResponseProjectsScansList result = WebServiceProxy.GetProjectsWithScans(sessionId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseSourceID UploadProjectWithDefaultSettings(string sessionId, ProjectBasicSettings projectSettings, LocalCodeContainer localCodeContainer)
	{
		CxWSResponseSourceID result = WebServiceProxy.UploadProjectWithDefaultSettings(sessionId, projectSettings, localCodeContainer);
		return result;
	}
	[WebMethod()]
	public CxWSResponseSourceContainer GetSourceCodeForScan(long scanId)
	{
		CxWSResponseSourceContainer result = WebServiceProxy.GetSourceCodeForScan(scanId);
		return result;
	}
	[WebMethod()]
	public CxQueryCollectionResponse GetQueryCollectionForLanguage(string sessionId, int projectType, long projectId)
	{
        log.Debug("[CxPortalWebService]- Inside GetQueryCollectionForLanguage");
		CxQueryCollectionResponse result = WebServiceProxy.GetQueryCollectionForLanguage(sessionId, projectType, projectId);
        new CxTeamMentor().TMFilterFor_CxQueryCollectionResponse(result);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UploadQueries(string sessionId, CxWSQueryGroup[] queries)
	{
		CxWSBasicRepsonse result = WebServiceProxy.UploadQueries(sessionId, queries);
		return result;
	}
	[WebMethod()]
	public CxWSResponseBasicScanData AddScanResultsToProject(string sessionId, long projectId, string sourceId, AuditResultsCollection resultsCollection, string comment)
	{
		CxWSResponseBasicScanData result = WebServiceProxy.AddScanResultsToProject(sessionId, projectId, sourceId, resultsCollection, comment);
		return result;
	}
	[WebMethod()]
	public CxWSResponseResultCollection GetResults(string sessionId, long scanId)
	{
        log.Debug("[CxPortalWebService]- Inside GetResults");
		CxWSResponseResultCollection result = WebServiceProxy.GetResults(sessionId, scanId);
        new CxTeamMentor().TMFilterFor_CxWSResponseResultCollection(result);
		return result;
	}
	[WebMethod()]
	public CXWSResponseResultSummary GetResultSummary(string sessionId, long scanId)
	{
        log.Debug("[CxPortalWebService]- Inside GetResultSummary");
		CXWSResponseResultSummary result = WebServiceProxy.GetResultSummary(sessionId, scanId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseCache GetCache(string sessionId, long scanId)
	{
		CxWSResponseCache result = WebServiceProxy.GetCache(sessionId, scanId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseLoginData Login(Credentials applicationCredentials, int lcid)
	{
		CxWSResponseLoginData result = WebServiceProxy.Login(applicationCredentials, lcid);
		return result;
	}
	[WebMethod()]
	public CxWSResponseLoginData SsoLogin(Credentials encryptedCredentials, int lcid)
	{
		CxWSResponseLoginData result = WebServiceProxy.SsoLogin(encryptedCredentials, lcid);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse Logout(string sessionID)
	{
		CxWSBasicRepsonse result = WebServiceProxy.Logout(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseLoginData LoginBySID(string sessionID)
	{
		CxWSResponseLoginData result = WebServiceProxy.LoginBySID(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseGroupList GetAssociatedGroupsList(string SessionID)
	{
		CxWSResponseGroupList result = WebServiceProxy.GetAssociatedGroupsList(SessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseConfigSetList GetConfigurationSetList(string SessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetConfigurationSetList");
		CxWSResponseConfigSetList result = WebServiceProxy.GetConfigurationSetList(SessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse IsValidProjectName(string SessionID, string ProjectName, string GroupId)
	{
		CxWSBasicRepsonse result = WebServiceProxy.IsValidProjectName(SessionID, ProjectName, GroupId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseFileSystemLayer GetSharedFileSystemLayer(string SessionID, string Path, Credentials UserCredentials)
	{
		CxWSResponseFileSystemLayer result = WebServiceProxy.GetSharedFileSystemLayer(SessionID, Path, UserCredentials);
		return result;
	}
	[WebMethod()]
	public CxWSResponseFileSystemLayer GetRepositoryFileSystemLayer(string SessionID, string Path, SourceControlSettings SourceControlSettings)
	{
		CxWSResponseFileSystemLayer result = WebServiceProxy.GetRepositoryFileSystemLayer(SessionID, Path, SourceControlSettings);
		return result;
	}
	[WebMethod()]
	public CxWSResponseSourceActionList GetSourceControlActionList(string SessionID, string teamId)
	{
        log.Debug("[CxPortalWebService]- Inside GetSourceControlActionList");
		CxWSResponseSourceActionList result = WebServiceProxy.GetSourceControlActionList(SessionID, teamId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseSourceActionList GetPostScanActionList(string SessionID, string teamId)
	{
		CxWSResponseSourceActionList result = WebServiceProxy.GetPostScanActionList(SessionID, teamId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseProjectID CreateNewProject(string SessionID, ProjectConfiguration Project)
	{
		CxWSResponseProjectID result = WebServiceProxy.CreateNewProject(SessionID, Project);
		return result;
	}
	[WebMethod()]
	public CxWSResponseRunID CreateAndRunProject(string SessionID, ProjectSettings ProjectSettings, LocalCodeContainer LocalCodeContainer, bool visibleToOtherUsers)
	{
		CxWSResponseRunID result = WebServiceProxy.CreateAndRunProject(SessionID, ProjectSettings, LocalCodeContainer, visibleToOtherUsers);
		return result;
	}
	[WebMethod()]
	public CxWSResponseRunID RunScanAndAddToProject(string sessionId, ProjectSettings projectSettings, LocalCodeContainer localCodeContainer, bool visibleToUtherUsers)
	{
		CxWSResponseRunID result = WebServiceProxy.RunScanAndAddToProject(sessionId, projectSettings, localCodeContainer, visibleToUtherUsers);
		return result;
	}
	[WebMethod()]
	public CxWSResponseCountLines CountLines(string sessionId, LocalCodeContainer localCodeContainer)
	{
		CxWSResponseCountLines result = WebServiceProxy.CountLines(sessionId, localCodeContainer);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanStatusArray GetScansStatuses(string sessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetScansStatuses");
		CxWSResponseScanStatusArray result = WebServiceProxy.GetScansStatuses(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanStatus GetStatusOfSingleScan(string sessionID, string runId)
	{
		CxWSResponseScanStatus result = WebServiceProxy.GetStatusOfSingleScan(sessionID, runId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseQueueRunID PostponeScan(string sessionID, string RunId)
	{
		CxWSResponseQueueRunID result = WebServiceProxy.PostponeScan(sessionID, RunId);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CancelScan(string sessionID, string RunId)
	{
		CxWSBasicRepsonse result = WebServiceProxy.CancelScan(sessionID, RunId);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateProjectUserCredentials(string sessionID, long projectID, Credentials credentials)
	{
		CxWSBasicRepsonse result = WebServiceProxy.UpdateProjectUserCredentials(sessionID, projectID, credentials);
		return result;
	}
	[WebMethod()]
	public CxWSResponseProjectsData GetProjectsWithUserCredentials(string sessionID, string username)
	{
		CxWSResponseProjectsData result = WebServiceProxy.GetProjectsWithUserCredentials(sessionID, username);
		return result;
	}
	[WebMethod()]
	public CxWSResponseNameList GetProjectsCredentialUsers(string sessionID)
	{
		CxWSResponseNameList result = WebServiceProxy.GetProjectsCredentialUsers(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseProjectsDisplayData GetProjectsDisplayData(string sessionID)
	{
        log.Debug("[CxPortalWebService]- Inside GetProjectsDisplayData");
		CxWSResponseProjectsDisplayData result = WebServiceProxy.GetProjectsDisplayData(sessionID);
        
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse RunProjectImmediately(string sessionID, long projectID)
	{
		CxWSBasicRepsonse result = WebServiceProxy.RunProjectImmediately(sessionID, projectID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse RunProjectIncrementally(string sessionID, long projectID)
	{
		CxWSBasicRepsonse result = WebServiceProxy.RunProjectIncrementally(sessionID, projectID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse DeleteProject(string sessionID, long projectID)
	{
		CxWSBasicRepsonse result = WebServiceProxy.DeleteProject(sessionID, projectID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseProjectConfig GetProjectConfiguration(string sessionID, long projectID)
	{
		CxWSResponseProjectConfig result = WebServiceProxy.GetProjectConfiguration(sessionID, projectID);
		return result;
	}
	[WebMethod()]
	public CxWSResponsProjectProperties GetProjectProperties(string sessionID, long projectID, ScanType scanType)
	{
		CxWSResponsProjectProperties result = WebServiceProxy.GetProjectProperties(sessionID, projectID, scanType);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateProjectConfiguration(string sessionID, long projectID, ProjectConfiguration projectConfiguration)
	{
		CxWSBasicRepsonse result = WebServiceProxy.UpdateProjectConfiguration(sessionID, projectID, projectConfiguration);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateProjectIncrementalConfiguration(string sessionID, long projectID, ProjectConfiguration projectConfiguration)
	{
		CxWSBasicRepsonse result = WebServiceProxy.UpdateProjectIncrementalConfiguration(sessionID, projectID, projectConfiguration);
		return result;
	}
	[WebMethod()]
	public CxWSResponsProjectChartData GetProjectCharts(string sessionID, long projectID, ScanType scanType)
	{
		CxWSResponsProjectChartData result = WebServiceProxy.GetProjectCharts(sessionID, projectID, scanType);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse ResetIgnorePath(string sessionID, long ProjectId)
	{
		CxWSBasicRepsonse result = WebServiceProxy.ResetIgnorePath(sessionID, ProjectId);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse SetFalsePositiveFlag(string sessionID, long ResultId, long PathId, long projectId, bool falsePositiveFlag)
	{
		CxWSBasicRepsonse result = WebServiceProxy.SetFalsePositiveFlag(sessionID, ResultId, PathId, projectId, falsePositiveFlag);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateResultComment(string sessionID, long ResultId, long PathId, long projectId, string comment)
	{
		CxWSBasicRepsonse result = WebServiceProxy.UpdateResultComment(sessionID, ResultId, PathId, projectId, comment);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateResultState(string sessionID, long scanId, long PathId, long projectId, string Remarks, int ResultLabelType, string data)
	{
		CxWSBasicRepsonse result = WebServiceProxy.UpdateResultState(sessionID, scanId, PathId, projectId, Remarks, ResultLabelType, data);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateSetOfResultState(string sessionID, ResultStateData[] resultsStates)
	{
		CxWSBasicRepsonse result = WebServiceProxy.UpdateSetOfResultState(sessionID, resultsStates);
		return result;
	}
	[WebMethod()]
	public CxWSResponseRunID RunScanWithExistingProject(string sessionId, string projectName)
	{
		CxWSResponseRunID result = WebServiceProxy.RunScanWithExistingProject(sessionId, projectName);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScansDisplayData GetScansDisplayData(string sessionID, long projectID)
	{
        log.Debug("[CxPortalWebService]- Inside GetScansDisplayData");
		CxWSResponseScansDisplayData result = WebServiceProxy.GetScansDisplayData(sessionID, projectID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse DeleteScan(string sessionID, long ScanID)
	{
		CxWSBasicRepsonse result = WebServiceProxy.DeleteScan(sessionID, ScanID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanProperties GetScanProperties(string sessionID, long ScanID)
	{
		CxWSResponseScanProperties result = WebServiceProxy.GetScanProperties(sessionID, ScanID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateScanComment(string sessionID, long ScanID, string Comment)
	{
		CxWSBasicRepsonse result = WebServiceProxy.UpdateScanComment(sessionID, ScanID, Comment);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScansDisplayData GetScansDisplayDataForAllProjects(string sessionID)
	{
		CxWSResponseScansDisplayData result = WebServiceProxy.GetScansDisplayDataForAllProjects(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanSummary GetScanSummary(string i_SessionID, long i_ScanID)
	{
		CxWSResponseScanSummary result = WebServiceProxy.GetScanSummary(i_SessionID, i_ScanID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanCompareSummary GetScanCompareSummary(string sessionId, long oldScanId, long newScanId)
	{
		CxWSResponseScanCompareSummary result = WebServiceProxy.GetScanCompareSummary(sessionId, oldScanId, newScanId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanCompareReport GetScanCompareReport(string sessionId, long oldScanId, long newScanId)
	{
		CxWSResponseScanCompareReport result = WebServiceProxy.GetScanCompareReport(sessionId, oldScanId, newScanId);
		return result;
	}
	[WebMethod()]
	public CxWSResponceScanCompareResults GetCompareScanResults(string sessionId, long oldScanId, long newScanId)
	{
		CxWSResponceScanCompareResults result = WebServiceProxy.GetCompareScanResults(sessionId, oldScanId, newScanId);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CreateScanPDFReport(string sessionID, long scanID)
	{
		CxWSBasicRepsonse result = WebServiceProxy.CreateScanPDFReport(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CreateScannedFilesReport(string sessionID, long scanID)
	{
		CxWSBasicRepsonse result = WebServiceProxy.CreateScannedFilesReport(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CXWSResponseScanReportStatus GetScanPDFReportStatus(string sessionID, long scanID)
	{
		CXWSResponseScanReportStatus result = WebServiceProxy.GetScanPDFReportStatus(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CXWSResponseScanReportStatus GetScannedFilesReportStatus(string sessionID, long scanID)
	{
		CXWSResponseScanReportStatus result = WebServiceProxy.GetScannedFilesReportStatus(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanResults GetScanPDFReport(string sessionID, long scanID)
	{
		CxWSResponseScanResults result = WebServiceProxy.GetScanPDFReport(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanResults GetScannedFilesReport(string sessionID, long scanID)
	{
		CxWSResponseScanResults result = WebServiceProxy.GetScannedFilesReport(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CreateScanExcelReport(string sessionID, long scanID)
	{
		CxWSBasicRepsonse result = WebServiceProxy.CreateScanExcelReport(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CXWSResponseScanReportStatus GetScanExcelReportStatus(string sessionID, long scanID)
	{
		CXWSResponseScanReportStatus result = WebServiceProxy.GetScanExcelReportStatus(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanResults GetScanExcelReport(string sessionID, long scanID)
	{
		CxWSResponseScanResults result = WebServiceProxy.GetScanExcelReport(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CreateScanXMLReport(string sessionID, long scanID)
	{
		CxWSBasicRepsonse result = WebServiceProxy.CreateScanXMLReport(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CXWSResponseScanReportStatus GetScanXMLReportStatus(string sessionID, long scanID)
	{
		CXWSResponseScanReportStatus result = WebServiceProxy.GetScanXMLReportStatus(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanResults GetScanXMLReport(string sessionID, long scanID)
	{
		CxWSResponseScanResults result = WebServiceProxy.GetScanXMLReport(sessionID, scanID);
        if (result.ScanResults != null) { 
        new CxTeamMentor().TMFilterFor_CxWSResponseScanResults(result);
        }
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanResults GetScanXMLReportByRunId(string sessionID, string runId)
	{
		CxWSResponseScanResults result = WebServiceProxy.GetScanXMLReportByRunId(sessionID, runId);
        if (result.ScanResults != null)
        {
            new CxTeamMentor().TMFilterFor_CxWSResponseScanResults(result);
        }
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanResults GetScanPDFReportByRunId(string sessionID, string runId)
	{
		CxWSResponseScanResults result = WebServiceProxy.GetScanPDFReportByRunId(sessionID, runId);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CreateScanRTFReport(string sessionID, long scanID)
	{
		CxWSBasicRepsonse result = WebServiceProxy.CreateScanRTFReport(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CXWSResponseScanReportStatus GetScanRTFReportStatus(string sessionID, long scanID)
	{
		CXWSResponseScanReportStatus result = WebServiceProxy.GetScanRTFReportStatus(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanResults GetScanRTFReport(string sessionID, long scanID)
	{
		CxWSResponseScanResults result = WebServiceProxy.GetScanRTFReport(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseQueryDescription GetQueryDescription(string sessionId, int cweId)
	{
        log.Debug("[CxPortalWebService]- Inside GetQueryDescription");
		CxWSResponseQueryDescription result = WebServiceProxy.GetQueryDescription(sessionId, cweId);
	    result.IsSuccesfull = true;
	    result.ErrorMessage = string.Empty;
        new CxTeamMentor().TMFilterFor_CxWSResponseQueryDescription(cweId,result);
		return result;
	}
	[WebMethod()]
	public CxWSResponseSourceContent GetSourceByScanID(string sessionID, long scanID, string fileToRetreive)
	{
        log.Debug("[CxPortalWebService]- Inside GetSourceByScanID");
		CxWSResponseSourceContent result = WebServiceProxy.GetSourceByScanID(sessionID, scanID, fileToRetreive);
		return result;
	}
	[WebMethod()]
	public CxWSResponseResultStateList GetResultStateList(string sessionID)
	{
		CxWSResponseResultStateList result = WebServiceProxy.GetResultStateList(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse ForgotPassword(string loginUrl, string userName, string email)
	{
		CxWSBasicRepsonse result = WebServiceProxy.ForgotPassword(loginUrl, userName, email);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse ResetPasswordByEmail(string passwordChangePageUrl, string email)
	{
		CxWSBasicRepsonse result = WebServiceProxy.ResetPasswordByEmail(passwordChangePageUrl, email);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CheckChangePasswordToken(string token)
	{
		CxWSBasicRepsonse result = WebServiceProxy.CheckChangePasswordToken(token);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse ChangePasswordWithToken(string token, string password)
	{
		CxWSBasicRepsonse result = WebServiceProxy.ChangePasswordWithToken(token, password);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse ChangePassword(string sessionID, string oldPsw, string newPsw)
	{
		CxWSBasicRepsonse result = WebServiceProxy.ChangePassword(sessionID, oldPsw, newPsw);
		return result;
	}
	[WebMethod()]
	public CxWSResponseGroupList GetCompanies()
	{
		CxWSResponseGroupList result = WebServiceProxy.GetCompanies();
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse RegisterPendingUser(WebClientPendingUser pendingUser, string pendingUsersTableUrl)
	{
		CxWSBasicRepsonse result = WebServiceProxy.RegisterPendingUser(pendingUser, pendingUsersTableUrl);
		return result;
	}
	[WebMethod()]
	public CxWSResponsePendingUsersList GetPendingUsersList(string sessionID)
	{
		CxWSResponsePendingUsersList result = WebServiceProxy.GetPendingUsersList(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse DeletePendingUsers(string sessionID, int[] userIdList)
	{
		CxWSBasicRepsonse result = WebServiceProxy.DeletePendingUsers(sessionID, userIdList);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse ApprovePendingUsers(string sessionID, WebClientApprovedUser[] userList)
	{
		CxWSBasicRepsonse result = WebServiceProxy.ApprovePendingUsers(sessionID, userList);
		return result;
	}
	[WebMethod()]
	public CxWSResponseProfileData GetUserProfileData(string sessionID)
	{
		CxWSResponseProfileData result = WebServiceProxy.GetUserProfileData(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateUserProfileData(string sessionID, ProfileData userProfileData)
	{
		CxWSBasicRepsonse result = WebServiceProxy.UpdateUserProfileData(sessionID, userProfileData);
		return result;
	}
	[WebMethod()]
	public CxWSResponseUserData GetAllUsers(string sessionID)
	{
		CxWSResponseUserData result = WebServiceProxy.GetAllUsers(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseUserData GetAllUsersInGroup(string sessionID, string groupID, bool isRecursive)
	{
		CxWSResponseUserData result = WebServiceProxy.GetAllUsersInGroup(sessionID, groupID, isRecursive);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse DeleteUser(string sessionID, int userID)
	{
		CxWSBasicRepsonse result = WebServiceProxy.DeleteUser(sessionID, userID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseHierarchyGroupNodes GetHierarchyGroupTree(string sessionID)
	{
		CxWSResponseHierarchyGroupNodes result = WebServiceProxy.GetHierarchyGroupTree(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse SetUserActivationState(string sessionID, int userID, bool activationState)
	{
		CxWSBasicRepsonse result = WebServiceProxy.SetUserActivationState(sessionID, userID, activationState);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse AddNewUser(string sessionID, UserData userData, CxUserTypes userType)
	{
		CxWSBasicRepsonse result = WebServiceProxy.AddNewUser(sessionID, userData, userType);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateUserData(string sessionID, UserData userData)
	{
		CxWSBasicRepsonse result = WebServiceProxy.UpdateUserData(sessionID, userData);
		return result;
	}
	[WebMethod()]
	public CxWSResponseServerLicenseData GetServerLicenseData(string sessionID)
	{
		CxWSResponseServerLicenseData result = WebServiceProxy.GetServerLicenseData(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseUsersLicenseData GetUsersLicenseData(string sessionID, string groupID)
	{
		CxWSResponseUsersLicenseData result = WebServiceProxy.GetUsersLicenseData(sessionID, groupID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseCompaniesLicenseData GetCompaniesLicenseData(string sessionID, string groupID)
	{
		CxWSResponseCompaniesLicenseData result = WebServiceProxy.GetCompaniesLicenseData(sessionID, groupID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseSPLicenseData GetSPLicenseData(string sessionID, string groupID)
	{
		CxWSResponseSPLicenseData result = WebServiceProxy.GetSPLicenseData(sessionID, groupID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateUserGroups(string sessionID, long userID, Group[] unsubscribedGroups, Group[] subscribedGroups, Role role)
	{
		CxWSBasicRepsonse result = WebServiceProxy.UpdateUserGroups(sessionID, userID, unsubscribedGroups, subscribedGroups, role);
		return result;
	}
	[WebMethod()]
	public CxWSResponseGroupList GetCompaniesList()
	{
		CxWSResponseGroupList result = WebServiceProxy.GetCompaniesList();
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse IsValidUserName(string sessionID, string username)
	{
		CxWSBasicRepsonse result = WebServiceProxy.IsValidUserName(sessionID, username);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse IsValidEmail(string email)
	{
		CxWSBasicRepsonse result = WebServiceProxy.IsValidEmail(email);
		return result;
	}
	[WebMethod()]
	public CxWSResponseNameList GetAvailbleDomainNames(string sessionID)
	{
		CxWSResponseNameList result = WebServiceProxy.GetAvailbleDomainNames(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseDomainUserList GetAllUsersFromDomain(string sessionID, string domain, string i_SearchPattern)
	{
		CxWSResponseDomainUserList result = WebServiceProxy.GetAllUsersFromDomain(sessionID, domain, i_SearchPattern);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CreateNewTeam(string sessionID, string parentTeamID, string newTeamName)
	{
		CxWSBasicRepsonse result = WebServiceProxy.CreateNewTeam(sessionID, parentTeamID, newTeamName);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse RenameTeam(string sessionID, string teamID, string newTeamName)
	{
		CxWSBasicRepsonse result = WebServiceProxy.RenameTeam(sessionID, teamID, newTeamName);
		return result;
	}
	[WebMethod()]
	public CxWSResponseTeamData GetAllTeams(string sessionID)
	{
		CxWSResponseTeamData result = WebServiceProxy.GetAllTeams(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse DeleteTeam(string sessionID, string teamID)
	{
		CxWSBasicRepsonse result = WebServiceProxy.DeleteTeam(sessionID, teamID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CreateNewCompany(string sessionID, string ParentSP, string newTCompanyName, int companyManagers, int scanners, int reviewers, bool allowActions)
	{
		CxWSBasicRepsonse result = WebServiceProxy.CreateNewCompany(sessionID, ParentSP, newTCompanyName, companyManagers, scanners, reviewers, allowActions);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CreateNewServiceProvider(string sessionID, string newSpName, int spManagersint, int companyManagers, int scanners, int reviewers)
	{
		CxWSBasicRepsonse result = WebServiceProxy.CreateNewServiceProvider(sessionID, newSpName, spManagersint, companyManagers, scanners, reviewers);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse RenameCompany(string sessionID, string teamID, string newTeamName)
	{
		CxWSBasicRepsonse result = WebServiceProxy.RenameCompany(sessionID, teamID, newTeamName);
		return result;
	}
	[WebMethod()]
	public CxWSResponseTeamData GetAllCompanies(string sessionID)
	{
		CxWSResponseTeamData result = WebServiceProxy.GetAllCompanies(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseTeamData GetAllSPs(string sessionID)
	{
		CxWSResponseTeamData result = WebServiceProxy.GetAllSPs(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse DeleteCompany(string sessionID, string teamID)
	{
		CxWSBasicRepsonse result = WebServiceProxy.DeleteCompany(sessionID, teamID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse DeleteSP(string sessionID, string teamID)
	{
		CxWSBasicRepsonse result = WebServiceProxy.DeleteSP(sessionID, teamID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse IsValidCompanyName(string sessionID, string companyName, string serviceProviderID)
	{
		CxWSBasicRepsonse result = WebServiceProxy.IsValidCompanyName(sessionID, companyName, serviceProviderID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseTeamData GetCompanyTeams(string sessionID, string companyID)
	{
		CxWSResponseTeamData result = WebServiceProxy.GetCompanyTeams(sessionID, companyID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseTeamData GetServiceProviderTeams(string sessionID, string spID)
	{
		CxWSResponseTeamData result = WebServiceProxy.GetServiceProviderTeams(sessionID, spID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseTeamData GetServiceProviderCompanies(string sessionID, string spID)
	{
		CxWSResponseTeamData result = WebServiceProxy.GetServiceProviderCompanies(sessionID, spID);
		return result;
	}
	[WebMethod()]
	public CxWsResponseCompanyProperties GetCompanyProperties(string sessionID, string companyID)
	{
		CxWsResponseCompanyProperties result = WebServiceProxy.GetCompanyProperties(sessionID, companyID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse SetUserAsCompanyManager(string sessionID, string companyID, long userID)
	{
		CxWSBasicRepsonse result = WebServiceProxy.SetUserAsCompanyManager(sessionID, companyID, userID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse SetUserAsServiceProviderManager(string sessionID, string spID, long userID)
	{
		CxWSBasicRepsonse result = WebServiceProxy.SetUserAsServiceProviderManager(sessionID, spID, userID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse IsValidServiceProviderName(string sessionID, string serviceProviderName)
	{
		CxWSBasicRepsonse result = WebServiceProxy.IsValidServiceProviderName(sessionID, serviceProviderName);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateCompanyProperties(string sessionID, string companyID, string companyName, int maxReviewers, int maxScanners, int maxManagers)
	{
		CxWSBasicRepsonse result = WebServiceProxy.UpdateCompanyProperties(sessionID, companyID, companyName, maxReviewers, maxScanners, maxManagers);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse SetSystemSettings(string sessionID, SystemSettings settings)
	{
		CxWSBasicRepsonse result = WebServiceProxy.SetSystemSettings(sessionID, settings);
		return result;
	}
	[WebMethod()]
	public CxWSResponseSystemLanguages GetServerLanguageList(string sessionID)
	{
		CxWSResponseSystemLanguages result = WebServiceProxy.GetServerLanguageList(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWsResponseSystemSettings GetSystemSettings(string sessionID)
	{
		CxWsResponseSystemSettings result = WebServiceProxy.GetSystemSettings(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse VerifySupportedVersion(CxClientType clientType, string clientVersion, string APIVersion)
	{
		CxWSBasicRepsonse result = WebServiceProxy.VerifySupportedVersion(clientType, clientVersion, APIVersion);
		return result;
	}
}
