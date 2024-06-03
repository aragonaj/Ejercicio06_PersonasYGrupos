namespace Ejercicio06_PersonasYGrupos.Services
{
    public class ObtenerAnno : IFecha
    {
        public int getAnno(string fecha)
        {
            string anno = fecha.Substring(6);
            return int.Parse(anno);
        }
    }
}
