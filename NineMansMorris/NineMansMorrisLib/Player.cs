namespace NineMansMorrisLib
{
    public class Player
    {
        private Player()
        {
            turn = false;
        }
        private bool turn; // field

        public bool Turn   // property
        {
            get { return turn; }   // get method
            set { turn = value; }  // set method
        }
    }
}