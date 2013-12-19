using System;
//O2File:CxEclipseWebService.cs
using System.Web.Services;
using FluentSharp.CoreLib;
using log4net;
using TeamMentor.Checkmarx;

namespace Checkmarx712Eclipse
{
[WebService(Namespace = "http://Checkmarx.com/v7")]
public class CxEclipseWebService
{
	public CxEclipseWebService_Proxy _web_Service { get; set; }
    private ILog log = LogManager.GetLogger(typeof(CxEclipseWebService));
	public CxEclipseWebService()
	{
        var config = new CXConfiguration();
        var data = config.secretData_Load();
	    if (data.notNull())
	    {
	        var uri = new Uri(data.CheckMarx_WebService_EndPoint);
            var endpoint = uri.hostUrl() + ":" + uri.Port + "/CxWebInterface/Eclipse/CxEclipseWebService.asmx";
	        log.Debug("[EclipseWebService] Original Eclipse EndPoint located at =>" + endpoint);
	        _web_Service = new CxEclipseWebService_Proxy(endpoint);
	    }
        else
        {
            log.Error("[EclipseWebService] Configuration file was not found");
            throw new Exception("[EclipseWebService] Configuration file was not found");
        }
	}
	[WebMethod()]
	public CxWSResponseLoginData Login(Credentials applicationCredentials, int lcid)
	{
        log.Debug("[EclipseWebService] Inside Login");
		CxWSResponseLoginData result = _web_Service.Login(applicationCredentials, lcid);
		return result;
	}
	[WebMethod()]
	public CxWSResponseQueryDescription GetQueryDescription(string sessionId, int cweId)
	{
        log.Debug("[EclipseWebService]- Inside GetQueryDescription");
		CxWSResponseQueryDescription result = _web_Service.GetQueryDescription(sessionId, cweId);
        result.IsSuccesfull = true;
        result.ErrorMessage = string.Empty;
        new CxTeamMentor().TMFilterFor_CxWSResponseQueryDescription(cweId, result);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse VerifySupportedVersion(CxClientType clientType, string clientVersion, string APIVersion)
	{
        log.Debug("[EclipseWebService]- Inside VerifySupportedVersion");
		CxWSBasicRepsonse result = _web_Service.VerifySupportedVersion(clientType, clientVersion, APIVersion);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse Logout(string sessionID)
	{
        log.Debug("[EclipseWebService]- Inside Logout");
		CxWSBasicRepsonse result = _web_Service.Logout(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseLoginData SsoLogin(Credentials encryptedCredentials, int lcid)
	{
        log.Debug("[EclipseWebService]- Inside SsoLogin");
		CxWSResponseLoginData result = _web_Service.SsoLogin(encryptedCredentials, lcid);
		return result;
	}
	[WebMethod()]
	public CxWSResponsePresetList GetPresetList(string SessionID)
	{
        log.Debug("[EclipseWebService]- Inside GetPresetList");
		CxWSResponsePresetList result = _web_Service.GetPresetList(SessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseProjectConfig GetProjectConfiguration(string sessionID, long projectID)
	{
        log.Debug("[EclipseWebService]- Inside GetProjectConfiguration");
		CxWSResponseProjectConfig result = _web_Service.GetProjectConfiguration(sessionID, projectID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseRunID RunScanAndAddToProject(string sessionId, ProjectSettings projectSettings, LocalCodeContainer localCodeContainer, bool visibleToUtherUsers)
	{
        log.Debug("[EclipseWebService]- Inside RunScanAndAddToProject");
		CxWSResponseRunID result = _web_Service.RunScanAndAddToProject(sessionId, projectSettings, localCodeContainer, visibleToUtherUsers);
		return result;
	}
	[WebMethod()]
	public CxWSResponseRunID CreateAndRunProject(string SessionID, ProjectSettings ProjectSettings, LocalCodeContainer LocalCodeContainer, bool visibleToOtherUsers)
	{
        log.Debug("[EclipseWebService]- Inside CreateAndRunProject");
		CxWSResponseRunID result = _web_Service.CreateAndRunProject(SessionID, ProjectSettings, LocalCodeContainer, visibleToOtherUsers);
		return result;
	}
	[WebMethod()]
	public CxWSResponceScanResults GetResultsForQuery(string sessionID, long scanId, long queryId)
	{
        log.Debug("[EclipseWebService]- Inside GetResultsForQuery");
		CxWSResponceScanResults result = _web_Service.GetResultsForQuery(sessionID, scanId, queryId);
		return result;
	}
	[WebMethod()]
	public CxWSResponceResultPath GetResultPath(string sessionId, long scanId, long pathId)
	{
        log.Debug("[EclipseWebService]- Inside GetResultPath");
		CxWSResponceResultPath result = _web_Service.GetResultPath(sessionId, scanId, pathId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseProjectsDisplayData GetProjectsDisplayData(string sessionID)
	{
        log.Debug("[EclipseWebService]- Inside GetProjectsDisplayData");
		CxWSResponseProjectsDisplayData result = _web_Service.GetProjectsDisplayData(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScansDisplayData GetScansDisplayData(string sessionID, long projectID)
	{
        log.Debug("[EclipseWebService]- Inside GetScansDisplayData");
		CxWSResponseScansDisplayData result = _web_Service.GetScansDisplayData(sessionID, projectID);
		return result;
	}
	[WebMethod()]
	public CxWSResponceQuerisForScan GetQueriesForScan(string sessionID, long scanId)
	{
        log.Debug("[EclipseWebService]- Inside GetQueriesForScan");
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
        log.Debug("[EclipseWebService]- Inside SetFalsePositiveFlag");
		CxWSBasicRepsonse result = _web_Service.SetFalsePositiveFlag(sessionID, ResultId, PathId, projectId, falsePositiveFlag);
		return result;
	}
	[WebMethod()]
	public CxWSResponseResultStateList GetResultStateList(string sessionID)
	{
        log.Debug("[EclipseWebService]- Inside GetResultStateList");
		CxWSResponseResultStateList result = _web_Service.GetResultStateList(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseUserData GetAllUsers(string sessionID)
	{
        log.Debug("[EclipseWebService]- Inside GetAllUsers");
		CxWSResponseUserData result = _web_Service.GetAllUsers(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateSetOfResultState(string sessionID, ResultStateData[] resultsStates)
	{
        log.Debug("[EclipseWebService]- Inside UpdateSetOfResultState");
		CxWSBasicRepsonse result = _web_Service.UpdateSetOfResultState(sessionID, resultsStates);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateResultState(string sessionID, long scanId, long PathId, long projectId, string Remarks, int ResultLabelType, string data)
	{
        log.Debug("[EclipseWebService]- Inside UpdateResultState");
		CxWSBasicRepsonse result = _web_Service.UpdateResultState(sessionID, scanId, PathId, projectId, Remarks, ResultLabelType, data);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateProjectIncrementalConfiguration(string sessionID, long projectID, ProjectConfiguration projectConfiguration)
	{
        log.Debug("[EclipseWebService]- Inside UpdateProjectIncrementalConfiguration");
		CxWSBasicRepsonse result = _web_Service.UpdateProjectIncrementalConfiguration(sessionID, projectID, projectConfiguration);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanStatusArray GetScansStatuses(string sessionID)
	{
        log.Debug("[EclipseWebService]- Inside GetScansStatuses");
		CxWSResponseScanStatusArray result = _web_Service.GetScansStatuses(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse IsValidProjectName(string SessionID, string ProjectName, string GroupId)
	{
        log.Debug("[EclipseWebService]- Inside IsValidProjectName");
		CxWSBasicRepsonse result = _web_Service.IsValidProjectName(SessionID, ProjectName, GroupId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseGroupList GetAssociatedGroupsList(string SessionID)
	{
        log.Debug("[EclipseWebService]- Inside GetAssociatedGroupsList");
		CxWSResponseGroupList result = _web_Service.GetAssociatedGroupsList(SessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseConfigSetList GetConfigurationSetList(string SessionID)
	{
        log.Debug("[EclipseWebService]- Inside GetConfigurationSetList");
		CxWSResponseConfigSetList result = _web_Service.GetConfigurationSetList(SessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse CancelScan(string sessionID, string RunId)
	{
        log.Debug("[EclipseWebService]- Inside CancelScan");
		CxWSBasicRepsonse result = _web_Service.CancelScan(sessionID, RunId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanStatus GetStatusOfSingleScan(string sessionID, string runId)
	{
        log.Debug("[EclipseWebService]- Inside GetStatusOfSingleScan");
		CxWSResponseScanStatus result = _web_Service.GetStatusOfSingleScan(sessionID, runId);
		return result;
	}
	[WebMethod()]
	public CxWSCreateReportResponse CreateScanReport(string sessionID, CxWSReportRequest reportRequest)
	{
        log.Debug("[EclipseWebService]- Inside CreateScanReport");
		CxWSCreateReportResponse result = _web_Service.CreateScanReport(sessionID, reportRequest);
		return result;
	}
	[WebMethod()]
	public CxWSReportStatusResponse GetScanReportStatus(string SessionID, long ReportID)
	{
        log.Debug("[EclipseWebService]- Inside GetScanReportStatus");
		CxWSReportStatusResponse result = _web_Service.GetScanReportStatus(SessionID, ReportID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseScanResults GetScanReport(string SessionID, long ReportID)
	{
        log.Debug("[EclipseWebService]- Inside GetScanReport");
		CxWSResponseScanResults result = _web_Service.GetScanReport(SessionID, ReportID);
        if (result.notNull() && result.IsSuccesfull && result.ScanResults.notNull())
            new CxTeamMentor().TMFilterFor_CxWSResponseScanResults(result);
		return result;
	}
}
}
