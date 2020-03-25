namespace HarrisPharmacy.App.Models.BotModels
{
    public class ServerRecipientActivitiesModel
    {
        public AssessmentModel Assessment { get; private set; } = new AssessmentModel();
        public TherapeuticInterventionModel TherapeuticIntervention { get; private set; } = new TherapeuticInterventionModel();
    }
}