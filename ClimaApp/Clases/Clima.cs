namespace ClimaApp.Clases{
    public class Clima{

        public Clima() {
            this.Pais = string.Empty;
            this.Ciudad = string.Empty;
            this.Titulo = string.Empty;
            this.Temperatura = string.Empty;
            this.Viento = string.Empty;
            this.Humedad = string.Empty;
            this.Amanecer = string.Empty;
            this.Atardecer = string.Empty;
        }

        public object Pais { get; set; }
        public object Ciudad { get; set; }
        public object Titulo { get; set; }
        public object Temperatura { get; set; }
        public object Viento { get; set; }
        public object Humedad { get; set; }
        public object Visibilidad { get; set; }
        public object Amanecer { get; set; }
        public object Atardecer { get; set; }
    }
}
