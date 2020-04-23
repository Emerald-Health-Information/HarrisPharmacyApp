/*

Harrison1 COSC 471 2019

File = ServerRecipientActivitiesModel.cs

Author = Taylor Adam

Date = 2020 - 03 - 20

License = MIT

            Modification History

Version     Author Date           Desc
v 1.0		Taylor Adam     2020-03-20			Created

*/namespace HarrisPharmacy.App.Models.BotModels
{
    public class ServerRecipientActivitiesModel
    {
        public AssessmentModel Assessment { get; private set; } = new AssessmentModel();
        public TherapeuticInterventionModel TherapeuticIntervention { get; private set; } = new TherapeuticInterventionModel();
    }
}