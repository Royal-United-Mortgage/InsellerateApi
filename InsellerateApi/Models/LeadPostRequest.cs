using System.Text.Json.Serialization;

namespace InsellerateApi.Models;

public class LeadPostRequest
{
    public LeadPostRequest(LmbLeadRequest? lmbLeadRequest)
    {
        Root = new Root
        {
            Row = [new Row(lmbLeadRequest?.LmbLeads.LmbLead ?? throw new InvalidOperationException())]
        };
    }
    [JsonPropertyName("root")]
    public Root Root { get; set; }
}

public class Root
{
    [JsonPropertyName("row")]
    public required List<Row> Row { get; set; }
}

public class Row
    {
        public Row(LmbLead lmbLead)
        {
            Ref_Id = lmbLead.LeadID;
            First_Name = lmbLead.FirstName;
            Last_Name = lmbLead.LastName;
            Phone = lmbLead.Phone1;
            Mobile = lmbLead.Phone2;
            Work = lmbLead.WorkPhoneExt1;
            Email = lmbLead.Email;
            SSN = lmbLead.SSN;
            Address = lmbLead.StreetAddress;
            City_Name = lmbLead.City;
            State_Name = lmbLead.State;
            Zip_Code = lmbLead.ZipCode;
            Mailing_Address1 = lmbLead.MailStreetAddress;
            Mailing_City = lmbLead.MailCity;
            Mailing_State = lmbLead.MailState;
            Mailing_Zipcode = lmbLead.MailZipCode;
            DateOfBirth = lmbLead.BirthDate;
            Veteran = lmbLead.Veteran == "true";
            Borrower_married = lmbLead.MaritalStatus == "Married";
            Home_Value = decimal.TryParse(lmbLead.ExistingPropertyValue, out var homeValue) ? homeValue : null;
            Loan1_PurposeType_Proposed = lmbLead.LoanPurpose;
            Loan1_Type_Proposed = lmbLead.PreferredLoanType;
            Loan1_InitialAmount_Proposed = decimal.TryParse(lmbLead.DesiredLoanAmount, out var loanAmount) ? loanAmount : null;
            Purchase_Amount = decimal.TryParse(lmbLead.Cashout, out var cashOut) ? cashOut : null;
            First_Name_Co = lmbLead.B2_FirstName;
            Last_Name_Co = lmbLead.B2_LastName;
            SSN_Co = lmbLead.B2_SSN;
            Mailing_Address1_Co = lmbLead.B2_MailStreetAddress;
            Mailing_City_Co = lmbLead.B2_MailCity;
            Mailing_State_Co = lmbLead.B2_MailState;
            Mailing_Zipcode_Co = lmbLead.B2_MailZipCode;
            DateOfBirth_Co = lmbLead.B2_BirthDate;
            Employment_Status = lmbLead.OccupationalStatus;
            Employer = lmbLead.EmployerName;
            BaseIncome = decimal.TryParse(lmbLead.GrossMonthlyIncome?.Replace("$", ""), out var income) ? income : null;
            BaseIncome_Co = decimal.TryParse(lmbLead.B2_GrossMonthlyIncome, out var incomeCo) ? incomeCo : null;
            Borrower_other_income = decimal.TryParse(lmbLead.MonthlyDebtPayments, out var otherIncome) ? otherIncome : null;
            Notes = lmbLead.ConsumerComments;
            Other3 = lmbLead.FilterID;
            LeadCost = decimal.TryParse(lmbLead.Price?.Replace("$", ""), out var leadCost) ? leadCost : null;
            
        }

        [JsonPropertyName("Ref_Id")]
        public string? Ref_Id { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Phone { get; set; }
        public string? Work { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? SSN { get; set; }
        public string? Address { get; set; }
        public string? City_Name { get; set; }
        public string? State_Name { get; set; }
        public string? Zip_Code { get; set; }
        public string? Mailing_Address1 { get; set; }
        public string? Mailing_City { get; set; }
        public string? Mailing_State { get; set; }
        public string? Mailing_Zipcode { get; set; }
        public string? DateOfBirth { get; set; }
        public bool? Veteran { get; set; }
        public bool? Borrower_married { get; set; }
        public decimal? Home_Value { get; set; }
        public string? Loan1_PurposeType_Proposed { get; set; }
        public string? Loan1_Type_Proposed { get; set; }
        public string? Loan1_Rate_Proposed { get; set; }
        public decimal? Loan1_InitialAmount_Proposed { get; set; }
        public decimal? Purchase_Amount { get; set; }
        public string? Los_Loan_Number { get; set; }
        public string? First_Name_Co { get; set; }
        public string? Last_Name_Co { get; set; }
        public string? Phone_Co { get; set; }
        public string? Work_Co { get; set; }
        public string? Mobile_Co { get; set; }
        public string? Email_Co { get; set; }
        public string? SSN_Co { get; set; }
        public string? Mailing_Address1_Co { get; set; }
        public string? Mailing_City_Co { get; set; }
        public string? Mailing_State_Co { get; set; }
        public string? Mailing_Zipcode_Co { get; set; }
        public string? DateOfBirth_Co { get; set; }
        public bool? Veteran_Co { get; set; }
        public string? Employment_Status { get; set; }
        public string? Employer { get; set; }
        public string? Employment_Address { get; set; }
        public string? Employment_City { get; set; }
        public string? Employment_State { get; set; }
        public string? Employment_Zipcode { get; set; }
        public string? Employer_Co { get; set; }
        public string? Employment_Address_Co { get; set; }
        public string? Employment_City_Co { get; set; }
        public string? Employment_State_Co { get; set; }
        public string? Employment_Zipcode_Co { get; set; }
        public decimal? LeadCost { get; set; }
        public decimal? BaseIncome { get; set; }
        public decimal? BaseIncome_Co { get; set; }
        public decimal? Borrower_other_income { get; set; }
        public string? Notes { get; set; }
        public string? Other3 { get; set; }
    }