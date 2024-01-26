using System.ComponentModel.DataAnnotations;

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

        public Devise(int id, string? nomDevise, double taux)
        {
            this.Id = id;
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

        [Required]
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
