namespace ITest.Services.Data
{
    public interface IUserAnswersService
    {
        void AddUserAnswer(string userTestId, string answerId);
    }
}