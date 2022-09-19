namespace pharmacy_management_system
{
    internal class sqlcommand
    {
        internal object parameters;
        private string v;

        public sqlcommand()
        {
        }

        public sqlcommand(string v)
        {
            this.v = v;
        }

        public sqlcommand(string v, sqlconnection con) : this(v)
        {
            Con = con;
        }

        public sqlconnection Con { get; }
    }
}