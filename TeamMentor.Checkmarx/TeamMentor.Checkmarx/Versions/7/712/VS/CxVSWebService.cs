//O2File:CxVSWebService.cs

using System;
using System.Web.Services;
using FluentSharp.CoreLib;
using log4net;
using TeamMentor.Checkmarx;

namespace Checkmarx712VS
{
[WebService(Namespace = "http://Checkmarx.com/v7")]
public class CxVSWebService
{
	public CxVSWebService_Proxy _web_Service { get; set; }
    private ILog log = LogManager.GetLogger(typeof(CxVSWebService));
	public CxVSWebService()
	{
        var config = new CXConfiguration();
        var data = config.secretData_Load();
	    var uri = new Uri(data.CheckMarx_WebService_EndPoint);
        var endpoint = uri.hostUrl() + ":" + uri.Port + "/cxwebinterface/VS/CxVSWebService.asmx";
        log.Debug("Original Visual Studio EndPoint located at =>" + endpoint);
      
		_web_Service = new CxVSWebService_Proxy(endpoint);
	}
	[WebMethod()]
	public CxWSResponseLoginData Login(Credentials applicationCredentials, int lcid)
	{
        log.Debug("[VisualStudio] Inside Login");
		CxWSResponseLoginData result = _web_Service.Login(applicationCredentials, lcid);
		return result;
	}
	[WebMethod()]
	public CxWSResponseQueryDescription GetQueryDescription(string sessionId, int cweId)
	{
        log.Debug("[VisualStudio] Inside GetQueryDescription");
		CxWSResponseQueryDescription result = _web_Service.GetQueryDescription(sessionId, cweId);
        result.IsSuccesfull = true;
        result.ErrorMessage = string.Empty;
        new CxTeamMentor().TMFilterFor_CxWSResponseQueryDescription(cweId, result);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse VerifySupportedVersion(CxClientType clientType, string clientVersion, string APIVersion)
	{
        log.Debug("[VisualStudio] Inside VerifySupportedVersion");
		CxWSBasicRepsonse result = _web_Service.VerifySupportedVersion(clientType, clientVersion, APIVersion);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse Logout(string sessionID)
	{
        log.Debug("[VisualStudio] Inside Logout");
		CxWSBasicRepsonse result = _web_Service.Logout(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseLoginData SsoLogin(Credentials encryptedCredentials, int lcid)
	{
        log.Debug("[VisualStudio] Inside SsoLogin");
		CxWSResponseLoginData result = _web_Service.SsoLogin(encryptedCredentials, lcid);
		return result;
	}
	[WebMethod()]
	public CxWSResponsePresetList GetPresetList(string SessionID)
	{
        log.Debug("[VisualStudio] Inside GetPresetList");
		CxWSResponsePresetList result = _web_Service.GetPresetList(SessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseProjectConfig GetProjectConfiguration(string sessionID, long projectID)
	{
        log.Debug("[VisualStudio] Inside GetProjectConfiguration");
		CxWSResponseProjectConfig result = _web_Service.GetProjectConfiguration(sessionID, projectID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseRunID RunScanAndAddToProject(string sessionId, ProjectSettings projectSettings, LocalCodeContainer localCodeContainer, bool visibleToUtherUsers)
	{
        log.Debug("[VisualStudio] Inside RunScanAndAddToProject");
		CxWSResponseRunID result = _web_Service.RunScanAndAddToProject(sessionId, projectSettings, localCodeContainer, visibleToUtherUsers);
		return result;
	}
	[WebMethod()]
	public CxWSResponseRunID CreateAndRunProject(string SessionID, ProjectSettings ProjectSettings, LocalCodeContainer LocalCodeContainer, bool visibleToOtherUsers)
	{
        log.Debug("[VisualStudio] Inside CreateAndRunProject");
		CxWSResponseRunID result = _web_Service.CreateAndRunProject(SessionID, ProjectSettings, LocalCodeContainer, visibleToOtherUsers);
		return result;
	}
	[WebMethod()]
	public CxWSResponceScanResults GetResultsForQuery(string sessionID, long scanId, long queryId)
	{
        log.Debug("[VisualStudio] Inside GetResultsForQuery");
		CxWSResponceScanResults result = _web_Service.GetResultsForQuery(sessionID, scanId, queryId);
		return result;
	}
	[WebMethod()]
	public CxWSResponceResultPath GetResultPath(string sessionId, long scanId, long pathId)
	{
        log.Debug("[VisualStudio] Inside GetResultPath");
		CxWSResponceResultPath result = _web_Service.GetResultPath(sessionId, scanId, pathId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseProjectsDisplayData GetProjectsDisplayData(string sessionID)
	{
        log.Debug("[VisualStudio] Inside GetProjectsDisplayData");
		CxWSResponseProjectsDisplayData result = _web_Service.GetProjectsDisplayData(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScansDisplayData GetScansDisplayData(string sessionID, long projectID)
	{
        log.Debug("[VisualStudio] Inside GetScansDisplayData");
		CxWSResponseScansDisplayData result = _web_Service.GetScansDisplayData(sessionID, projectID);
		return result;
	}
	[WebMethod()]
	public CxWSResponceQuerisForScan GetQueriesForScan(string sessionID, long scanId)
	{
        log.Debug("[VisualStudio]- Inside GetQueriesForScan");
		CxWSResponceQuerisForScan result = _web_Service.GetQueriesForScan(sessionID, scanId);
        
        if (result != null && result.Queries != null)
        {
            new CxTeamMentor().TMFilterFor_CxWSResponceQuerisForScan(result);
        }
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse SetFalsePositiveFlag(string sessionID, long ResultId, long PathId, long projectId, bool falsePositiveFlag)
	{
        log.Debug("[VisualStudio]- Inside SetFalsePositiveFlag");
		CxWSBasicRepsonse result = _web_Service.SetFalsePositiveFlag(sessionID, ResultId, PathId, projectId, falsePositiveFlag);
		return result;
	}
	[WebMethod()]
	public CxWSResponseResultStateList GetResultStateList(string sessionID)
	{
        log.Debug("[VisualStudio]- Inside GetResultStateList");
		CxWSResponseResultStateList result = _web_Service.GetResultStateList(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseUserData GetAllUsers(string sessionID)
	{
        log.Debug("[VisualStudio]- Inside GetAllUsers");
		CxWSResponseUserData result = _web_Service.GetAllUsers(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateSetOfResultState(string sessionID, ResultStateData[] resultsStates)
	{
        log.Debug("[VisualStudio]- Inside UpdateSetOfResultState");
		CxWSBasicRepsonse result = _web_Service.UpdateSetOfResultState(sessionID, resultsStates);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateResultState(string sessionID, long scanId, long PathId, long projectId, string Remarks, int ResultLabelType, string data)
	{
        log.Debug("[VisualStudio]- Inside UpdateResultState");
		CxWSBasicRepsonse result = _web_Service.UpdateResultState(sessionID, scanId, PathId, projectId, Remarks, ResultLabelType, data);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateProjectIncrementalConfiguration(string sessionID, long projectID, ProjectConfiguration projectConfiguration)
	{
        log.Debug("[VisualStudio]- Inside UpdateProjectIncrementalConfiguration");
		CxWSBasicRepsonse result = _web_Service.UpdateProjectIncrementalConfiguration(sessionID, projectID, projectConfiguration);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanStatusArray GetScansStatuses(string sessionID)
	{
        log.Debug("[VisualStudio]- Inside GetScansStatuses");
		CxWSResponseScanStatusArray result = _web_Service.GetScansStatuses(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse IsValidProjectName(string SessionID, string ProjectName, string GroupId)
	{
        log.Debug("[VisualStudio]- Inside IsValidProjectName");
		CxWSBasicRepsonse result = _web_Service.IsValidProjectName(SessionID, ProjectName, GroupId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseGroupList GetAssociatedGroupsList(string SessionID)
	{
        log.Debug("[VisualStudio]- Inside GetAssociatedGroupsList");
		CxWSResponseGroupList result = _web_Service.GetAssociatedGroupsList(SessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseConfigSetList GetConfigurationSetList(string SessionID)
	{
        log.Debug("[VisualStudio]- Inside GetConfigurationSetList");
		CxWSResponseConfigSetList result = _web_Service.GetConfigurationSetList(SessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CancelScan(string sessionID, string RunId)
	{
        log.Debug("[VisualStudio]- Inside CancelScan");
		CxWSBasicRepsonse result = _web_Service.CancelScan(sessionID, RunId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanStatus GetStatusOfSingleScan(string sessionID, string runId)
	{
        log.Debug("[VisualStudio]- Inside GetStatusOfSingleScan");
		CxWSResponseScanStatus result = _web_Service.GetStatusOfSingleScan(sessionID, runId);
		return result;
	}
	[WebMethod()]
	public CxWSCreateReportResponse CreateScanReport(string sessionID, CxWSReportRequest reportRequest)
	{
        log.Debug("[VisualStudio]- Inside CreateScanReport");
		CxWSCreateReportResponse result = _web_Service.CreateScanReport(sessionID, reportRequest);
		return result;
	}
	[WebMethod()]
	public CxWSReportStatusResponse GetScanReportStatus(string SessionID, long ReportID)
	{
        log.Debug("[VisualStudio]- Inside GetScanReportStatus");
		CxWSReportStatusResponse result = _web_Service.GetScanReportStatus(SessionID, ReportID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanResults GetScanReport(string SessionID, long ReportID)
	{
        log.Debug("[VisualStudio]- Inside GetScanReport");
		CxWSResponseScanResults result = _web_Service.GetScanReport(SessionID, ReportID);
		return result;
	}
	[WebMethod()]
	public CxWSResponceQuerisForScanAndId GetQueriesForScanByRunId(string sessionID, string runId)
	{
        log.Debug("[VisualStudio]- Inside GetScanReport");
		CxWSResponceQuerisForScanAndId result = _web_Service.GetQueriesForScanByRunId(sessionID, runId);
        
        if (result != null && result.Queries != null)
        {
            new CxTeamMentor().TMFilterFor_CxWSResponceQuerisForScanAndId(result);
        }

		return result;
	}
	[WebMethod()]
	public CXWSResponseScanReportStatus GetScanXMLReportStatus(string sessionID, long scanID)
	{
        log.Debug("[VisualStudio]- Inside GetScanXMLReportStatus");
		CXWSResponseScanReportStatus result = _web_Service.GetScanXMLReportStatus(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseResultPaths GetResultPathsForQuery(string sessionId, long scanId, long queryId)
	{
        log.Debug("[VisualStudio]- Inside GetResultPathsForQuery");
		CxWSResponseResultPaths result = _web_Service.GetResultPathsForQuery(sessionId, scanId, queryId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseUserData GetProjectAssignUsers(string sessionID, long projectId)
	{
        log.Debug("[VisualStudio]- Inside GetProjectAssignUsers");
		CxWSResponseUserData result = _web_Service.GetProjectAssignUsers(sessionID, projectId);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CreateScanXMLReport(string sessionID, long scanID)
	{
        log.Debug("[VisualStudio]- Inside CreateScanXMLReport");
		CxWSBasicRepsonse result = _web_Service.CreateScanXMLReport(sessionID, scanID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanResults GetScanXMLReport(string sessionID, long scanID)
	{
        log.Debug("[VisualStudio]- Inside GetScanXMLReport");
		CxWSResponseScanResults result = _web_Service.GetScanXMLReport(sessionID, scanID);
		return result;
	}
}
}