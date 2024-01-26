namespace ConvertisseurWS.Models
{
    public class Devise
    {
        private int id;
        private string? nomDevise;
        private double taux;

        public Devise()
        {
        }

        public Devise(string? nomDevise, double taux)
        {
            this.NomDevise = nomDevise;
            this.Taux = taux;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string? NomDevise
        {
            get
            {
                return nomDevise;
            }

            set
            {
                nomDevise = value;
            }
        }

        public double Taux
        {
            get
            {
                return this.taux;
            }

            set
            {
                this.taux = value;
            }
        }
    }
}
