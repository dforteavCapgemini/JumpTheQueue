namespace Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Dto
{
    public class VisitorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool AcceptedCommercial { get; set; }
        public bool AcceptedTerms { get; set; }
        public bool UserType { get; set; }

        public AccessCodeCto AccessCode { get; set; }
    }
}
