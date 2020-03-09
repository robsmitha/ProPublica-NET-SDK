namespace ProPublica
{
    public class ProPublica
    {
        private string ApiKey { get; set; }
        public ProPublica(string apiKey) 
        {
            ApiKey = apiKey;
        }

        private Members members;
        public Members Members
        {
            get => members ??= new Members(ApiKey);
            set => members = value;
        }

        private Bills bills;
        public Bills Bills
        {
            get => bills ??= new Bills(ApiKey);
            set => bills = value;
        }

        private Committees committees;
        public Committees Committees
        {
            get => committees ??= new Committees(ApiKey);
            set => committees = value;
        }

        private Lobbying lobbying;
        public Lobbying Lobbying
        {
            get => lobbying ??= new Lobbying(ApiKey);
            set => lobbying = value;
        }

        private Statements statements;
        public Statements Statements
        {
            get => statements ??= new Statements(ApiKey);
            set => statements = value;
        }

        private Votes votes;
        public Votes Votes
        {
            get => votes ??= new Votes(ApiKey);
            set => votes = value;
        }
    }
}
