/*

Harrison1 COSC 471 2019

File = AssessmentModel.cs

Author = Taylor Adam

Date = 2020 - 03 - 20

License = MIT

            Modification History

Version     Author Date           Desc
v 1.0		Taylor Adam     2020-03-20			Created

*/
namespace HarrisPharmacy.App.Models.BotModels
{
    public class AssessmentModel
    {
        public int NonFTFAssessment { get; set; }
        public int FTFAssessment { get; set; }
        public int TelephoneElectronicAssessment { get; set; }
        public int TelephoneElectronicPlan { get; set; }
    }
}