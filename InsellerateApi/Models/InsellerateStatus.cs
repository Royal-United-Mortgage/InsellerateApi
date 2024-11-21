namespace InsellerateApi.Models;


// Custom attribute for storing StatusId and ActivityId
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class StatusMappingAttribute(int statusId, int activityId) : Attribute
{
    public int StatusId { get; } = statusId;
    public int ActivityId { get; } = activityId;
}
public enum InsellerateStatus
{
    [StatusMapping(10000, 10000)]
    NewLeadReceived,
    
    [StatusMapping(10000, 10106)]
    NewLeadNew48Hr,
    
    [StatusMapping(10000, 10050)]
    NewLeadContacted,
    
    [StatusMapping(10001, 10025)]
    ContactedContacted,
    
    [StatusMapping(10001, 10026)]
    ContactedExportToEncompass,
    
    [StatusMapping(10001, 10102)]
    ContactedReturnToNew,
    
    [StatusMapping(10003, 10022)]
    FileStartedFileStarted,
    
    [StatusMapping(10003, 10103)]
    FileStartedReturnToNew,
    
    [StatusMapping(10004, 10015)]
    DiscoveryDiscovery,
    
    [StatusMapping(10004, 10040)]
    DiscoveryPropScheduled,
    
    [StatusMapping(10004, 10096)]
    DiscoveryPropNotScheduled,
    
    [StatusMapping(10004, 10097)]
    DiscoveryDidntAnswer,
    
    [StatusMapping(10004, 10016)]
    DiscoveryDocsRequested,
    
    [StatusMapping(10004, 10017)]
    DiscoveryPreApproval,
    
    [StatusMapping(10005, 10010)]
    PrePipelineApplication,
    
    [StatusMapping(10005, 10098)]
    PrePipelineProposedFollowUp,
    
    [StatusMapping(10005, 10099)]
    PrePipelineProposedShopping,
    
    [StatusMapping(10005, 10100)]
    PrePipelineProposedSpouse,
    
    [StatusMapping(10005, 10101)]
    PrePipelineProposedSold,
    
    [StatusMapping(10005, 10011)]
    PrePipelineInitialDisclosuresSent,
    
    [StatusMapping(10005, 10012)]
    PrePipelineInitialDisclosuresReceived,
    
    [StatusMapping(10005, 10013)]
    PrePipelineSubmissionReview,
    
    [StatusMapping(10007, 10027)]
    SubToCaseSubToCaseOpening,
    
    [StatusMapping(10007, 10051)]
    SubToCaseOrderedOpened,
    
    [StatusMapping(10007, 10053)]
    SubToCaseSubmittal,
    
    [StatusMapping(10016, 10004)]
    SuspendedSendToProcessing,
    
    [StatusMapping(10016, 10095)]
    SuspendedManagerReviewFolder,
    
    [StatusMapping(10009, 10023)]
    ApprovedWithConditionsApprovedWithConditions,
    
    [StatusMapping(10009, 10024)]
    ApprovedWithConditionsFinalApproval,
    
    [StatusMapping(10008, 10008)]
    ClearToCloseApproval,
    
    [StatusMapping(10008, 10009)]
    ClearToClosePreClosing,
    
    [StatusMapping(10008, 10014)]
    ClearToCloseDocSigning,
    
    [StatusMapping(10008, 10021)]
    ClearToCloseFundingReady,
    
    [StatusMapping(10010, 10005)]
    FundedFunding,
    
    [StatusMapping(10010, 10006)]
    FundedFrontEndReceived,
    
    [StatusMapping(10010, 10007)]
    FundedCompletion,
    
    [StatusMapping(10010, 10104)]
    FundedDuplicateExportToEncompass,
    
    [StatusMapping(10011, 10033)]
    NoSaleNurture,
    
    [StatusMapping(10011, 10034)]
    NoSaleNotInterested,
    
    [StatusMapping(10011, 10054)]
    NoSaleCouldNotReachBorrower,
    
    [StatusMapping(10011, 10001)]
    NoSaleBadNumber,
    
    [StatusMapping(10011, 10037)]
    NoSaleLostToCompetitor,
    
    [StatusMapping(10011, 10039)]
    NoSaleUnacceptablePropertyType,
    
    [StatusMapping(10011, 10055)]
    NoSaleUnacceptablePropertyCondition,
    
    [StatusMapping(10011, 10052)]
    NoSaleNoBenefit,
    
    [StatusMapping(10011, 10035)]
    NoSaleLowCreditScore,
    
    [StatusMapping(10011, 10107)]
    NoSaleNotEnoughAssets,
    
    [StatusMapping(10011, 10036)]
    NoSaleDti,
    
    [StatusMapping(10011, 10002)]
    NoSaleLtv,
    
    [StatusMapping(10011, 10038)]
    NoSaleBankruptcyForeclosure,
    
    [StatusMapping(10011, 10041)]
    NoSaleLateMortgagePayment,
    
    [StatusMapping(10011, 10056)]
    NoSaleIneligibleFindings,
    
    [StatusMapping(10011, 10093)]
    NoSaleMortgageSeasoning,
    
    [StatusMapping(10011, 10094)]
    NoSaleProposedNotSold,
    
    [StatusMapping(10011, 10044)]
    NoSaleLosWithdrawnAdverse,
    
    [StatusMapping(10011, 10105)]
    NoSaleDeadDiscoveries,
    
    [StatusMapping(10011, 10042)]
    NoSaleOther,
    
    [StatusMapping(10011, 10003)]
    NoSaleDuplicateLead,
    
    [StatusMapping(10012, 10043)]
    DoNotContactDoNotContact,
    
    [StatusMapping(10006, 10020)]
    DuplicateLeadDuplicateLead,
    
    [StatusMapping(10013, 10081)]
    ConnectionPotentialPartnerNewConnection,
    
        [StatusMapping(10013, 10082)]
    ConnectionPotentialPartnerMoveToRelationship,

    [StatusMapping(10013, 10083)]
    ConnectionPotentialPartnerMoveToPartner,

    [StatusMapping(10013, 10084)]
    ConnectionPotentialPartnerPhoneCall,

    [StatusMapping(10013, 10085)]
    ConnectionPotentialPartnerText,

    [StatusMapping(10013, 10086)]
    ConnectionPotentialPartnerEmail,

    [StatusMapping(10013, 10087)]
    ConnectionPotentialPartnerSocialMediaMessage,

    [StatusMapping(10013, 10090)]
    ConnectionPotentialPartnerFaceToFaceMeeting,

    [StatusMapping(10013, 10091)]
    ConnectionPotentialPartnerPresentation,

    [StatusMapping(10013, 10092)]
    ConnectionPotentialPartnerPartnerEvent,

    [StatusMapping(10014, 10069)]
    Relationship1To2DealsMoveToConnection,

    [StatusMapping(10014, 10070)]
    Relationship1To2DealsNewRelationship,

    [StatusMapping(10014, 10071)]
    Relationship1To2DealsMoveToPartner,

    [StatusMapping(10014, 10072)]
    Relationship1To2DealsPhoneCall,

    [StatusMapping(10014, 10073)]
    Relationship1To2DealsText,

    [StatusMapping(10014, 10074)]
    Relationship1To2DealsEmail,

    [StatusMapping(10014, 10075)]
    Relationship1To2DealsSocialMediaMessage,

    [StatusMapping(10014, 10078)]
    Relationship1To2DealsFaceToFaceMeeting,

    [StatusMapping(10014, 10079)]
    Relationship1To2DealsPresentation,

    [StatusMapping(10014, 10080)]
    Relationship1To2DealsPartnerEvent,

    [StatusMapping(10015, 10057)]
    PartnerReceiveAtLeastHalfMoveToConnection,

    [StatusMapping(10015, 10058)]
    PartnerReceiveAtLeastHalfMoveToRelationship,

    [StatusMapping(10015, 10059)]
    PartnerReceiveAtLeastHalfNewPartner,

    [StatusMapping(10015, 10060)]
    PartnerReceiveAtLeastHalfPhoneCall,

    [StatusMapping(10015, 10061)]
    PartnerReceiveAtLeastHalfText,

    [StatusMapping(10015, 10062)]
    PartnerReceiveAtLeastHalfEmail,

    [StatusMapping(10015, 10063)]
    PartnerReceiveAtLeastHalfSocialMediaMessage,

    [StatusMapping(10015, 10066)]
    PartnerReceiveAtLeastHalfFaceToFaceMeeting,

    [StatusMapping(10015, 10067)]
    PartnerReceiveAtLeastHalfPresentation,

    [StatusMapping(10015, 10068)]
    PartnerReceiveAtLeastHalfPartnerEvent

}


public static class InsellerateStatusExtensions
{
    private static (int StatusId, int ActivityId) GetStatusMapping(this InsellerateStatus status)
    {
        var type = typeof(InsellerateStatus);
        var memberInfo = type.GetMember(status.ToString()).FirstOrDefault();

        return memberInfo?.GetCustomAttributes(typeof(StatusMappingAttribute), false)
            .FirstOrDefault() is StatusMappingAttribute attribute 
            ? (attribute.StatusId, attribute.ActivityId) 
            : throw new ArgumentException("Invalid status");
    }

    public static object GetStatusObject(this InsellerateStatus status)
    {
        var (statusId, activityId) = status.GetStatusMapping();
        return new 
        {
            StatusId = statusId,
            ActivityId = activityId
        };
    }
}
