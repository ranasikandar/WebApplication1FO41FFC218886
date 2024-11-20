using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class NewBusiness : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["userId"] == null)
            //    Response.Redirect("Login.aspx");

            //if (Utils.RequiredValidation(Session)) // checking MFA state
            //{
            //    Response.Redirect("Login.aspx");
            //}

            //// Retrieve the query string parameter 'id' which should contain the 'crosk_ref'
            //string croskRef = Request.QueryString["id"];
            //yourRefTxt.Text = Session["ReferenceNum"].ToString();

            //if (!string.IsNullOrEmpty(croskRef))
            //{
            //    lblCroskReference.Text = croskRef;
            //}
            //else
            //{
            //    lblCroskReference.Text = "No Crosk Reference Provided";
            //    btnLogOff.Text = "Logout user: (" + Session["userId"].ToString() + ")";
            //}

            //yourRefTxt.Focus();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            // Validation logic (omitted for brevity, keep your existing validation code here)

            if (isValid)
            {
                // Prepare email details
                string toEmail = Environment.GetEnvironmentVariable("ToEmail");
                string subject = "My New Business Submission";
                string body = GenerateEmailBody(yourRefTxt.Text, clientAccountNumberTxt.Text, fullNameTxt.Text, addressTxt.Text, debtTypeTxt.Text, instructionsTxt.Text, TextBox13.Text, TextBox10.Text, TextBox9.Text, dobTxt.Text, phoneTxt.Text);
                string fromEmail = Environment.GetEnvironmentVariable("fromEmail");
                string smtpServer = Environment.GetEnvironmentVariable("smtpServer");
                string portnumberAsString = Environment.GetEnvironmentVariable("PortNum");
                int port = int.Parse(portnumberAsString);
                string smtpUsername = Environment.GetEnvironmentVariable("SmtpUsername");
                string smtpPassword = Environment.GetEnvironmentVariable("smtpPassword");

                // Handle file upload
                byte[] attachmentData = null;
                string attachmentName = null;

                if (fileUpload.HasFile)
                {
                    using (var ms = new MemoryStream())
                    {
                        fileUpload.PostedFile.InputStream.CopyTo(ms);
                        attachmentData = ms.ToArray();
                        attachmentName = Path.GetFileName(fileUpload.FileName);
                    }
                }

                // Send the email with the attachment
                SendEmail(toEmail, subject, body, fromEmail, smtpServer, port, smtpUsername, smtpPassword, attachmentData, attachmentName);

                // Clear form fields after submission
                foreach (System.Web.UI.Control ctrl in form1.Controls)
                {
                    if (ctrl is System.Web.UI.WebControls.TextBox)
                    {
                        ((System.Web.UI.WebControls.TextBox)ctrl).Text = string.Empty;
                    }
                }

                lblFormSubmitSuccess.Text = "New Business form submitted successfully";
            }
        }


        private void SendEmail(string toEmail, string subject, string body, string fromEmail, string smtpServer, int port, string smtpUsername, string smtpPassword, byte[] attachmentData, string attachmentName)
        {
            try
            {
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(fromEmail);
                    mail.To.Add(toEmail);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    // Attach the file if it exists
                    if (attachmentData != null && attachmentData.Length > 0 && !string.IsNullOrEmpty(attachmentName))
                    {
                        ////COMMENTED BY RANA
                        //using (var ms = new MemoryStream(attachmentData))
                        //{
                        //    var attachment = new Attachment(ms, attachmentName);
                        //    mail.Attachments.Add(attachment);
                        //}

                        ////ADDED BY RANA
                        mail.Attachments.Add(new Attachment(new MemoryStream(attachmentData), attachmentName));
                    }

                    using (var smtpClient = new SmtpClient(smtpServer, port))
                    {
                        smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                        smtpClient.EnableSsl = true;
                        smtpClient.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception message
                Console.WriteLine("Error sending email: " + ex.Message);
                errorFileUpload.Text = "Error sending email: " + ex.Message;
            }
        }

        public string GenerateEmailBody(
            string yourRef,
            string clientAccountNumber,
            string fullName,
            string address,
            string debtType,
            string instructions,
            string comments,
            string agreementDate,
            string balanceDue,
            string dateOfBirth,
            string phoneNumber)
        {
            // Format the dates to dd-MM-yyyy
            string formattedAgreementDate = DateTime.TryParse(agreementDate, out DateTime parsedAgreementDate) ? parsedAgreementDate.ToString("dd-MM-yyyy") : agreementDate;
            string formattedDateOfBirth = DateTime.TryParse(dateOfBirth, out DateTime parsedDOB) ? parsedDOB.ToString("dd-MM-yyyy") : dateOfBirth;

            return $@"
        <html>
        <body>
            <h2>New Business Request</h2>
                <table border='1' style='border-collapse: collapse;'>
         <tr>
             <td style='padding: 8px;'><strong>Reference:</strong></td>
             <td style='padding: 8px;'>{yourRef}</td>
         </tr>
         <tr>
             <td style='padding: 8px;'><strong>Client Account Number:</strong></td>
             <td style='padding: 8px;'>{clientAccountNumber}</td>
         </tr>
         <tr>
             <td style='padding: 8px;'><strong>Full Name:</strong></td>
             <td style='padding: 8px;'>{fullName}</td>
         </tr>
         <tr>
             <td style='padding: 8px;'><strong>Address:</strong></td>
             <td style='padding: 8px;'>{address}</td>
         </tr>
         <tr>
             <td style='padding: 8px;'><strong>Type of Debt (E.G Goods Supplied):</strong></td>
             <td style='padding: 8px;'>{debtType}</td>
         </tr>
         <tr>
             <td style='padding: 8px;'><strong>Special Instructions:</strong></td>
             <td style='padding: 8px;'>{instructions}</td>
         </tr>
         <tr>
             <td style='padding: 8px;'><strong>Comments:</strong></td>
             <td style='padding: 8px;'>{comments}</td>
         </tr>
         <tr>
             <td style='padding: 8px;'><strong>Agreement Date:</strong></td>
             <td style='padding: 8px;'>{formattedAgreementDate}</td>
         </tr>
         <tr>
             <td style='padding: 8px;'><strong>Balance Due:</strong></td>
             <td style='padding: 8px;'>{balanceDue}</td>
         </tr>
         <tr>
             <td style='padding: 8px;'><strong>Date of Birth:</strong></td>
             <td style='padding: 8px;'>{formattedDateOfBirth}</td>
         </tr>
         <tr>
             <td style='padding: 8px;'><strong>Phone Number:</strong></td>
             <td style='padding: 8px;'>{phoneNumber}</td>
         </tr>
     </table>
        </body>
        </html>";
        }

        protected void btnLogOff_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        ////ADDED BY RANA
        protected void TextBox13_TextChanged(object sender, EventArgs e)
        {


        }
    }
}