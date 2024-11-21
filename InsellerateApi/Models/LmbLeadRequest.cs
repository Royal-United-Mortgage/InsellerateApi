using System.Text.Json.Serialization;

namespace InsellerateApi.Models
{
    public class LmbLeadRequest
    {
        [JsonPropertyName("LmbLeads")]
        public LmbLeadsContainer LmbLeads { get; set; } = new();
    }

    public class LmbLeadsContainer
    {
        [JsonPropertyName("LmbLead")]
        public LmbLead LmbLead { get; set; } = new();
    }

    public class LmbLead
    {
        [JsonPropertyName("LeadType")]
        public string? LeadType { get; set; }

        [JsonPropertyName("LeadID")]
        public string? LeadID { get; set; }

        [JsonPropertyName("DateCreated")]
        public DateTime? DateCreated { get; set; }

        [JsonPropertyName("FirstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("LastName")]
        public string? LastName { get; set; }

        [JsonPropertyName("Email")]
        public string? Email { get; set; }

        [JsonPropertyName("SSN")]
        public string? SSN { get; set; }

        [JsonPropertyName("MaritalStatus")]
        public string? MaritalStatus { get; set; }

        [JsonPropertyName("SpouseFirstName")]
        public string? SpouseFirstName { get; set; }

        [JsonPropertyName("SpouseLastName")]
        public string? SpouseLastName { get; set; }

        [JsonPropertyName("MailStreetAddress")]
        public string? MailStreetAddress { get; set; }

        [JsonPropertyName("MailCity")]
        public string? MailCity { get; set; }

        [JsonPropertyName("MailState")]
        public string? MailState { get; set; }

        [JsonPropertyName("MailZipCode")]
        public string? MailZipCode { get; set; }

        [JsonPropertyName("BirthDate")]
        public string? BirthDate { get; set; }

        [JsonPropertyName("GrossMonthlyIncome")]
        public string? GrossMonthlyIncome { get; set; }

        [JsonPropertyName("OccupationalStatus")]
        public string? OccupationalStatus { get; set; }

        [JsonPropertyName("EmployerName")]
        public string? EmployerName { get; set; }

        [JsonPropertyName("EmploymentLength")]
        public string? EmploymentLength { get; set; }

        [JsonPropertyName("B2_FirstName")]
        public string? B2_FirstName { get; set; }

        [JsonPropertyName("B2_LastName")]
        public string? B2_LastName { get; set; }

        [JsonPropertyName("B2_SSN")]
        public string? B2_SSN { get; set; }

        [JsonPropertyName("B2_MailStreetAddress")]
        public string? B2_MailStreetAddress { get; set; }

        [JsonPropertyName("B2_MailCity")]
        public string? B2_MailCity { get; set; }

        [JsonPropertyName("B2_MailState")]
        public string? B2_MailState { get; set; }

        [JsonPropertyName("B2_MailZipCode")]
        public string? B2_MailZipCode { get; set; }

        [JsonPropertyName("B2_BirthDate")]
        public string? B2_BirthDate { get; set; }

        [JsonPropertyName("B2_GrossMonthlyIncome")]
        public string? B2_GrossMonthlyIncome { get; set; }

        [JsonPropertyName("Phone1")]
        public string? Phone1 { get; set; }

        [JsonPropertyName("WorkPhoneExt1")]
        public string? WorkPhoneExt1 { get; set; }

        [JsonPropertyName("Phone1Type")]
        public string? Phone1Type { get; set; }

        [JsonPropertyName("Phone2")]
        public string? Phone2 { get; set; }

        [JsonPropertyName("WorkPhoneExt2")]
        public string? WorkPhoneExt2 { get; set; }

        [JsonPropertyName("Phone2Type")]
        public string? Phone2Type { get; set; }

        [JsonPropertyName("ContactTime")]
        public string? ContactTime { get; set; }

        [JsonPropertyName("CreditProfile")]
        public string? CreditProfile { get; set; }

        [JsonPropertyName("MonthlyDebtPayments")]
        public string? MonthlyDebtPayments { get; set; }

        [JsonPropertyName("DesiredLoanAmount")]
        public string? DesiredLoanAmount { get; set; }

        [JsonPropertyName("ExistingPropertyValue")]
        public string? ExistingPropertyValue { get; set; }

        [JsonPropertyName("NewPropertyValue")]
        public string? NewPropertyValue { get; set; }

        [JsonPropertyName("PropertyFound")]
        public string? PropertyFound { get; set; }

        [JsonPropertyName("IntendedPropertyUse")]
        public string? IntendedPropertyUse { get; set; }

        [JsonPropertyName("StreetAddress")]
        public string? StreetAddress { get; set; }

        [JsonPropertyName("City")]
        public string? City { get; set; }

        [JsonPropertyName("State")]
        public string? State { get; set; }

        [JsonPropertyName("ZipCode")]
        public string? ZipCode { get; set; }

        [JsonPropertyName("PropertyState")]
        public string? PropertyState { get; set; }

        [JsonPropertyName("SearchZipCode")]
        public string? SearchZipCode { get; set; }

        [JsonPropertyName("PropertyCounty")]
        public string? PropertyCounty { get; set; }

        [JsonPropertyName("PropertyDescription")]
        public string? PropertyDescription { get; set; }

        [JsonPropertyName("PropertyPurchasedYear")]
        public string? PropertyPurchasedYear { get; set; }

        [JsonPropertyName("FirstMortgageBalance")]
        public string? FirstMortgageBalance { get; set; }

        [JsonPropertyName("FirstMortgageInterestRate")]
        public string? FirstMortgageInterestRate { get; set; }

        [JsonPropertyName("SecondMortgageBalance")]
        public string? SecondMortgageBalance { get; set; }

        [JsonPropertyName("SecondMortgageInterestRate")]
        public string? SecondMortgageInterestRate { get; set; }

        [JsonPropertyName("DesiredRateType")]
        public string? DesiredRateType { get; set; }

        [JsonPropertyName("DesiredMonthlyPayment")]
        public string? DesiredMonthlyPayment { get; set; }

        [JsonPropertyName("FirstMortgageRateType")]
        public string? FirstMortgageRateType { get; set; }

        [JsonPropertyName("CurrentNeedSituation")]
        public string? CurrentNeedSituation { get; set; }

        [JsonPropertyName("LoanPurpose")]
        public string? LoanPurpose { get; set; }

        [JsonPropertyName("LoanType")]
        public string? LoanType { get; set; }

        [JsonPropertyName("PreferredLoanType")]
        public string? PreferredLoanType { get; set; }

        [JsonPropertyName("LoanTimeframe")]
        public string? LoanTimeframe { get; set; }

        [JsonPropertyName("DownPayment")]
        public string? DownPayment { get; set; }

        [JsonPropertyName("Bankruptcy")]
        public string? Bankruptcy { get; set; }

        [JsonPropertyName("BankruptcyType")]
        public string? BankruptcyType { get; set; }

        [JsonPropertyName("IPAddress")]
        public string? IPAddress { get; set; }

        [JsonPropertyName("FirstTimeBuyer")]
        public string? FirstTimeBuyer { get; set; }

        [JsonPropertyName("HomeOwner")]
        public string? HomeOwner { get; set; }

        [JsonPropertyName("NeedPurchaseREAgent")]
        public string? NeedPurchaseREAgent { get; set; }

        [JsonPropertyName("REAgentName")]
        public string? REAgentName { get; set; }

        [JsonPropertyName("REAgentPhone")]
        public string? REAgentPhone { get; set; }

        [JsonPropertyName("NeedSellingREAgent")]
        public string? NeedSellingREAgent { get; set; }

        [JsonPropertyName("ConsumerComments")]
        public string? ConsumerComments { get; set; }

        [JsonPropertyName("AdditionalInformation")]
        public string? AdditionalInformation { get; set; }

        [JsonPropertyName("FilterID")]
        public string? FilterID { get; set; }

        [JsonPropertyName("Price")]
        public string? Price { get; set; }

        [JsonPropertyName("veteran")]
        public string? Veteran { get; set; }

        [JsonPropertyName("cashout")]
        public string? Cashout { get; set; }
    }
}
