namespace BLL
{
    public class BaseBLL
    {
        internal MYKINGDOMDataContext context;

        public BaseBLL()
        {
            context = new MYKINGDOMDataContext();
        }

        public string GetAIText() => context.GetAIText();
    }
}
