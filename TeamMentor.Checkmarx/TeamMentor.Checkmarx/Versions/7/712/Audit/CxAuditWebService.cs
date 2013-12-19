//O2File:CxAuditWebService.cs

using System;
using System.Web.Services;
using FluentSharp.CoreLib;
using log4net;
using TeamMentor.Checkmarx;

namespace Checkmarx712Audit
{
[WebService(Namespace = "http://Checkmarx.com/v7")]
public class CxAuditWebService
{
	public CxAuditWebService_Proxy _web_Service { get; set; }
    private ILog log = LogManager.GetLogger(typeof(CxAuditWebService));
	public CxAuditWebService()
	{
        var config = new CXConfiguration();
        var data = config.secretData_Load();
	    if (data.notNull())
	    {
	        var uri = new Uri(data.CheckMarx_WebService_EndPoint);
            var endpoint = uri.hostUrl() + ":" + uri.Port + "/cxwebinterface/Audit/CxAuditWebService.asmx";
	        log.Debug("[AuditWebService] Original Audit EndPoint located at =>" + endpoint);

	        _web_Service = new CxAuditWebService_Proxy(endpoint);
	    }
	    else
	    {
	        log.Error("[AuditWebService] Configuration file was not found");
            throw new Exception("[AuditWebService] Configuration file was not found");
	    }
	}
	[WebMethod()]
	public CxWSResponseLoginData Login(Credentials applicationCredentials, int lcid)
	{
	    log.Debug("[AuditWebService] - Inside Login"); 
		CxWSResponseLoginData result = _web_Service.Login(applicationCredentials, lcid);
		return result;
	}
	[WebMethod()]
	public CxWSResponseBasicScanData AddScanResultsToProject(string sessionId, long projectId, string sourceId, AuditResultsCollection resultsCollection, string comment)
	{
        log.Debug("[AuditWebService] - Inside AddScanResultsToProject"); 
		CxWSResponseBasicScanData result = _web_Service.AddScanResultsToProject(sessionId, projectId, sourceId, resultsCollection, comment);
		return result;
	}
	[WebMethod()]
	public CxWSResponseHierarchyGroupNodes GetAncestryGroupTree(string sessionID, string pTeamID)
	{
        log.Debug("[AuditWebService] - Inside GetAncestryGroupTree"); 
		CxWSResponseHierarchyGroupNodes result = _web_Service.GetAncestryGroupTree(sessionID, pTeamID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseCache GetCache(string sessionId, long scanId)
	{
        log.Debug("[AuditWebService] - Inside GetCache"); 
		CxWSResponseCache result = _web_Service.GetCache(sessionId, scanId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseHierarchyGroupNodes GetHierarchyGroupTree(string sessionID)
	{
        log.Debug("[AuditWebService] - Inside GetHierarchyGroupTree"); 
		CxWSResponseHierarchyGroupNodes result = _web_Service.GetHierarchyGroupTree(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponsePresetDetails GetPresetDetails(string sessionId, long id)
	{
        log.Debug("[AuditWebService] - Inside GetPresetDetails"); 
		CxWSResponsePresetDetails result = _web_Service.GetPresetDetails(sessionId, id);
		return result;
	}
	[WebMethod()]
	public CxWSResponsePresetList GetPresetList(string SessionID)
	{
        log.Debug("[AuditWebService] - Inside GetPresetList"); 
		CxWSResponsePresetList result = _web_Service.GetPresetList(SessionID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseProjectConfig GetProjectConfiguration(string sessionID, long projectID)
	{
        log.Debug("[AuditWebService] - Inside GetProjectConfiguration"); 
		CxWSResponseProjectConfig result = _web_Service.GetProjectConfiguration(sessionID, projectID);
		return result;
	}
	[WebMethod()]
	public CxWSResponseProjectsScansList GetProjectsWithScans(string sessionId)
	{
        log.Debug("[AuditWebService] - Inside GetProjectsWithScans"); 
		CxWSResponseProjectsScansList result = _web_Service.GetProjectsWithScans(sessionId);
		return result;
	}
	[WebMethod()]
	public CxQueryCollectionResponse GetQueryCollectionForLanguage(string sessionId, int projectType, long projectId)
	{
        log.Debug("[AuditWebService]- Inside GetQueryCollectionForLanguage");
		CxQueryCollectionResponse result = _web_Service.GetQueryCollectionForLanguage(sessionId, projectType, projectId);
        new CxTeamMentor().TMFilterFor_CxQueryCollectionResponse(result);
		return result;
	}
	[WebMethod()]
	public CxQueryCollectionResponse GetQueryCollectionForLanguageByTeamId(string sessionId, int projectType, string teamId)
	{
        log.Debug("[AuditWebService]- Inside GetQueryCollectionForLanguageByTeamId");
		CxQueryCollectionResponse result = _web_Service.GetQueryCollectionForLanguageByTeamId(sessionId, projectType, teamId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseQueryDescription GetQueryDescription(string sessionId, int cweId)
	{
        log.Debug("[AuditWebService]- Inside GetQueryDescription");
		CxWSResponseQueryDescription result = _web_Service.GetQueryDescription(sessionId, cweId);
        result.IsSuccesfull = true;
        result.ErrorMessage = string.Empty;
        new CxTeamMentor().TMFilterFor_CxWSResponseQueryDescription(cweId, result);
		return result;
	}
	[WebMethod()]
	public CxWSResponseResultCollection GetResults(string sessionId, long scanId)
	{
        log.Debug("[AuditWebService]- Inside GetResults");
		CxWSResponseResultCollection result = _web_Service.GetResults(sessionId, scanId);
        new CxTeamMentor().TMFilterFor_CxWSResponseResultCollection(result);
		return result;
	}
	[WebMethod()]
	public CxWSResponseResultStateList GetResultStateList(string sessionID)
	{
        log.Debug("[AuditWebService]- Inside GetResultStateList");
		CxWSResponseResultStateList result = _web_Service.GetResultStateList(sessionID);
		return result;
	}
	[WebMethod()]
	public CXWSResponseResultSummary GetResultSummary(string sessionId, long scanId)
	{
        log.Debug("[AuditWebService]- Inside GetResultSummary");
		CXWSResponseResultSummary result = _web_Service.GetResultSummary(sessionId, scanId);
		return result;
	}
	[WebMethod()]
	public CxWSResponseSourceContainer GetSourceCodeForScan(long scanId)
	{
        log.Debug("[AuditWebService]- Inside GetSourceCodeForScan");
		CxWSResponseSourceContainer result = _web_Service.GetSourceCodeForScan(scanId);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse Logout(string sessionID)
	{
        log.Debug("[AuditWebService]- Inside Logout");
		CxWSBasicRepsonse result = _web_Service.Logout(sessionID);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateResultState(string sessionID, long scanId, long PathId, long projectId, string Remarks, int ResultLabelType, string data)
	{
        log.Debug("[AuditWebService]- Inside UpdateResultState");
		CxWSBasicRepsonse result = _web_Service.UpdateResultState(sessionID, scanId, PathId, projectId, Remarks, ResultLabelType, data);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UpdateScanComment(string sessionID, long ScanID, string Comment)
	{
        log.Debug("[AuditWebService]- Inside UpdateScanComment");
		CxWSBasicRepsonse result = _web_Service.UpdateScanComment(sessionID, ScanID, Comment);
		return result;
	}
	[WebMethod()]
	public CxWSResponseSourceID UploadProjectWithDefaultSettings(string sessionId, ProjectBasicSettings projectSettings, LocalCodeContainer localCodeContainer)
	{
        log.Debug("[AuditWebService]- Inside UploadProjectWithDefaultSettings");
		CxWSResponseSourceID result = _web_Service.UploadProjectWithDefaultSettings(sessionId, projectSettings, localCodeContainer);
		return result;
	}
	[WebMethod()]
	public CxWSBasicRepsonse UploadQueries(string sessionId, CxWSQueryGroup[] queries)
	{
        log.Debug("[AuditWebService]- Inside UploadQueries");
		CxWSBasicRepsonse result = _web_Service.UploadQueries(sessionId, queries);
		return result;
	}
}
}
