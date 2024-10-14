
using System.Collections.Generic;
namespace diarioOnline.Models
{
    public class Emotions
    {
        private List<string> Neutral { get; set; }= new List<string>
    {
        "A veces es mejor tener días aburridos y sencillos, que días complejos y problemáticos.",
        "Un río calmo es más fácil de navegar.",
        "Tal vez puedas hacer algo nuevo, la sorpresa es una emoción interesante..."
    };
        private List<string> Enojado { get; set; } = new List<string>
        {
            "Respira, haz algo que te de paz.",
            "Lo que sea que te hizo enojar ya pasará, el tiempo calma.",
            "Es normal sentir enojo por alguna injusticia que hayas pasado, pero no dejes que te consuma."
        };
        private List<string> Feliz { get; set; } = new List<string>
        {
            "Que hermoso es poder aprovechar esos momentos felices mientras duran.",
            "Hasta las flores están sonriendo contigo hoy.",
            "\" Defender la alegría como una trinchera,<br/> defenderla del escándalo y la rutina,<br/>" +
            " de la miseria y los miserables" +
            "<br/> de las ausencias transitorias y las definitivas...\"</br>" +
            " -Mario Benedetti."
        };
        private List<string> Triste { get; set; } = new List<string> {
            "Si estás triste no lo ocultes. Llora si es necesario. Es expresando la tristeza lo que la convierte en tranquilidad",
            "Recuerda que siempre que llovió salió el sol.",
            "¿Has pensado en hablarlo con alguien? Tal vez una buena compañía haga la tristeza menos pesada."
        };

        private List<string> Ansioso { get; set; } = new List<string> {
            "Inhala...exhala...inhala...exhala...",
            "A veces hay que desacelerar un poco, no dejar que los nervios nos controlen.",
            "¿Has escuchado hablar de los juguetes anti-estrés? Son buenos para descargar la ansiedad."
        };
        public List<string> GetPhrasesByEmotion(string emotion)
        {
            return emotion switch
            {
                "Neutral" => Neutral,
                "Feliz" => Feliz,
                "Triste" => Triste,
                "Enojado" => Enojado,
                "Ansioso" => Ansioso,
                _ => new List<string>()
            };
        }
    }

}
