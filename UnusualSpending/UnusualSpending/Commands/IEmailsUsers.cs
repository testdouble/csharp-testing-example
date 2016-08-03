namespace UnusualSpending.Commands {
    public interface IEmailsUsers {
        void Email(long userId, string subject, string body);
    }
}