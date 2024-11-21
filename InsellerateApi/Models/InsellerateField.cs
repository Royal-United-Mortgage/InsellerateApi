using System.ComponentModel;

namespace InsellerateApi.Models;

public enum InsellerateField
{
    [Description("1")]
    CampaignID,
    
    [Description("2")]
    ReferenceID,
    
    [Description("3")]
    LOSFileID,
    
    [Description("6")]
    ResidenceType,
    
    [Description("7")]
    PropertyType,
    
    [Description("8")]
    PropertyAddress,
    
    [Description("10")]
    PropertyCity,
    
    [Description("11")]
    PropertyState,
    
    [Description("12")]
    PropertyZipCode,
    
    [Description("13")]
    PropertyCondition,
    
    [Description("17")]
    PurchaseDate,
    
    [Description("18")]
    PurchaseAmount,
    
    [Description("19")]
    CurrentLoanPurposeFirst,
    
    [Description("20")]
    CurrentLoanStartDateFirst,
    
    [Description("21")]
    CurrentLenderFirst,
    
    [Description("22")]
    CurrentLoanInitialAmountFirst,
    
    [Description("23")]
    CurrentLoanBalanceFirst,
    
    [Description("24")]
    CurrentLoanRateFirst,
    
    [Description("25")]
    CurrentLoanRateTypeFirst,
    
    [Description("26")]
    CurrentLoanPaymentPI_First,
    
    [Description("27")]
    CurrentLoanTermFirst,
    
    [Description("28")]
    CurrentLoanTypeFirst,
    
    [Description("29")]
    CurrentPMIAmount,
    
    [Description("31")]
    ProposedLoanRateType,
    
    [Description("32")]
    ProposedLoanRate,
    
    [Description("33")]
    ProposedInitialLoanAmount,
    
    [Description("34")]
    ProposedLoanPurpose,
    
    [Description("35")]
    ProposedLoanPaymentPI,
    
    [Description("37")]
    ProposedLoanTerm,
    
    [Description("38")]
    ProposedLoanType,
    
    [Description("39")]
    ProposedPMIAmount,
    
    [Description("59")]
    EstimatedValue,
    
    [Description("60")]
    CurrentLTV,
    
    [Description("62")]
    DocsRequestedDate,
    
    [Description("63")]
    Disposition,
    
    [Description("64")]
    LeadVendorFilterID,
    
    [Description("65")]
    LOSCustomExportErrorMessage,
    
    [Description("66")]
    AppraisalETA,
    
    [Description("68")]
    Underwriter,
    
    [Description("69")]
    LOWLockID,
    
    [Description("70")]
    LOWPropDate,
    
    [Description("71")]
    LOWLastAccessedDate,
    
    [Description("72")]
    FirstName,
    
    [Description("73")]
    LastName,
    
    [Description("75")]
    Email,
    
    [Description("77")]
    DOB,
    
    [Description("78")]
    HomePhone,
    
    [Description("79")]
    WorkPhone,
    
    [Description("80")]
    MobilePhone,
    
    [Description("83")]
    BestTimeToCall,
    
    [Description("85")]
    LoanGoals,
    
    [Description("86")]
    Veteran,
    
    [Description("94")]
    HOADues,
    
    [Description("104")]
    FirstNameCoborrower,
    
    [Description("105")]
    LastNameCoborrower,
    
    [Description("107")]
    EmailCoborrower,
    
    [Description("109")]
    DOBCoborrower,
    
    [Description("110")]
    HomePhoneCoborrower,
    
    [Description("112")]
    MobilePhoneCoborrower,
    
    [Description("118")]
    VeteranCoborrower,
    
    [Description("136")]
    MailingAddress,
    
    [Description("138")]
    MailingCity,
    
    [Description("139")]
    MailingState,
    
    [Description("140")]
    MailingZipCode,
    
    [Description("168")]
    LOSStatus,
    
    [Description("170")]
    ClosedDate,
    
    [Description("174")]
    AppraisedValue,
    
    [Description("175")]
    TotalIncome,
    
    [Description("181")]
    CreditScore,
    
    [Description("186")]
    ProcessorAssigned,
    
    [Description("189")]
    ApplicationID,
    
    [Description("191")]
    CreditPulledDate,
    
    [Description("192")]
    LoanEstimateDate,
    
    [Description("194")]
    PrequalificationDate,
    
    [Description("195")]
    RateLockedDate,
    
    [Description("196")]
    RateLockExpirationDate,
    
    [Description("199")]
    DisclosuresSentDate,
    
    [Description("200")]
    AppraisalOrderedDate,
    
    [Description("201")]
    AppraisalReceivedDate,
    
    [Description("204")]
    DisclosuresReceivedDate,
    
    [Description("206")]
    SellerRealEstateAgent,
    
    [Description("207")]
    BuyerRealEstateAgent,
    
    [Description("208")]
    LOWPropID,
    
    [Description("209")]
    DiscoveryTaker,
    
    [Description("211")]
    TimeLoanLastLoggedInto,
    
    [Description("213")]
    LastUserToLogIntoLoanFile,
    
    [Description("214")]
    ConditionsRemaining,
    
    [Description("216")]
    BottomRatio,
    
    [Description("217")]
    LockReadyDate,
    
    [Description("236")]
    EstimatedClosingDate,
    
    [Description("251")]
    PreQualDate,
    
    [Description("254")]
    PropertyInspectionCompletionDate,
    
    [Description("255")]
    PropertyInspectionScheduledDate,
    
    [Description("269")]
    LOSWithdrawnAdverse,
    
    [Description("270")]
    Campaign,
    
    [Description("272")]
    ReferralPartner,
    
    [Description("274")]
    LOSLoanGUID,
    
    [Description("283")]
    LOCKREADY,
    
    [Description("284")]
    MaximumPointsAllowed,
    
    [Description("286")]
    PreCloseIn,
    
    [Description("287")]
    PreCloseOut,
    
    [Description("288")]
    EarliestClosingDate,
    
    [Description("292")]
    NBSDocsRequired,
    
    [Description("294")]
    SiteInfo,
    
    [Description("297")]
    IntakeHotlistItems,
    
    [Description("303")]
    LosCreditPullReference,
    
    [Description("304")]
    LOSLoanFolder,
    
    [Description("382")]
    CreditScoreCoborrower,
    
    [Description("386")]
    PropertyTaxes,
    
    [Description("407")]
    NeededForPreClose,
    
    [Description("408")]
    AgentAtFundingName,
    
    [Description("409")]
    AgentAtFundingEmail,
    
    [Description("691")]
    ProposedCLTV,
    
    [Description("855")]
    FundedDate,
    
    [Description("1521")]
    ProcessorEmail,
    
    [Description("111")]
    WorkPhoneCoborrower
}

public static class InsellerateFieldExtensions
{
    public static string GetFieldId(this InsellerateField field)
    {
        var fieldInfo = field.GetType().GetField(field.ToString());
        var descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo!, typeof(DescriptionAttribute))!;
        return descriptionAttribute.Description;
    }
}