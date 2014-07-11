using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using System.Collections.Specialized;

namespace PListLoader
{
    public sealed class SampleDataCommon  
    {
        private static Uri _baseUri = new Uri("ms-appx:///");

        public SampleDataCommon(String uniqueId, String title, String subtitle, String imagePath, String description)
        {
            this._uniqueId = uniqueId;
            this._title = title;
            this._subtitle = subtitle;
            this._description = description;
            this._imagePath = imagePath;
        }

        private string _uniqueId = string.Empty;
        public string UniqueId
        {
            get { return this._uniqueId; }
            set { this.SetProperty(ref this._uniqueId, value); }
        }

        private string _title = string.Empty;
        public string Title
        {
            get { return this._title; }
            set { this.SetProperty(ref this._title, value); }
        }

        private string _subtitle = string.Empty;
        public string Subtitle
        {
            get { return this._subtitle; }
            set { this.SetProperty(ref this._subtitle, value); }
        }

        private string _description = string.Empty;
        public string Theme
        {
            get { return this._description; }
            set { this.SetProperty(ref this._description, value); }
        }
        protected bool SetProperty<T>(ref T storage, T value)
        {
            storage = value;
            return true;
        }

        private ImageSource _image = null;
        private String _imagePath = null;
        
        public String ImagePath 
        {
            get { return _imagePath; }
        }
        

        public ImageSource Image
        {
            get
            {
                if (this._image == null && this._imagePath != null)
                {
                    this._image = new BitmapImage(new Uri(SampleDataCommon._baseUri, this._imagePath));
                }
                return this._image;
            }

            set
            {
                this._imagePath = null;
                this.SetProperty(ref this._image, value);
            }
        }

        public void SetImage(String path)
        {
            this._image = null;
            this._imagePath = path;
            
        }

         
    }


    /// <summary>
    /// Creates a collection of groups and items with hard-coded content.
    /// 
    /// SampleDataSource initializes with placeholder data rather than live production
    /// data so that sample data is provided at both design-time and run-time.
    /// </summary>
    public sealed class  SampleDataSource
    {
        private static SampleDataSource _sampleDataSource = new SampleDataSource();

        private ObservableCollection<SampleDataCommon> AllGroups = new ObservableCollection<SampleDataCommon>();
      
        public static SampleDataCommon GetGroup(string uniqueId)
        {
            // Simple linear search is acceptable for small data sets
            var matches = _sampleDataSource.AllGroups.Where((group) => group.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public IList<String> getBackGrounds()
        {
            ObservableCollection<String> ret = new ObservableCollection<String>();
            for (int i = 0; i < AllGroups.Count; i++) {
                ret.Add(AllGroups[i].ImagePath);
            }
            return ret;
        }

        public IList<String> getTitles()
        {
            ObservableCollection<String> ret = new ObservableCollection<String>();
            for (int i = 0; i < AllGroups.Count; i++)
            {
                ret.Add(AllGroups[i].Title);
            }
            return ret;
        }

        public IList<String> getSubTitles()
        {

            ObservableCollection<String> ret = new ObservableCollection<String>();
            for (int i = 0; i < AllGroups.Count; i++)
            {
                ret.Add(AllGroups[i].Subtitle);
            }
            return ret;
        }

        public IList<String> getThemes()
        {

            ObservableCollection<String> ret = new ObservableCollection<String>();
            for (int i = 0; i < AllGroups.Count; i++)
            {
                ret.Add(AllGroups[i].Theme);
            }
            return ret;
        }


        public IList<String> getLocalidad()
        {
            String[] ints = { "Cabanaconde", "Cabanaconde", "Cabanaconde", "Achoma", "Callalli", "Cabanadonde", "Caylloma", "Chivay", "Yanque", "Chivay", "Tisco", "Coporaque", "Coporaque", "Tapay", "Yanque", "Tapay", "Pinchollo", "Chivay", "Sibayo", "Cabanacode", "Yanque", "Achoma", "Pinchollo", "Callalli", "Sibayo", "Coporaque", "Chivay", "Canocota" };
            List<String> lst = new List<String>();
            lst.AddRange(ints);
            return lst;
        }
        public IList<String> getUbicacion()
        {
            String[] ints = { "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma", "Queda en la Provincia de Caylloma" };
            List<String> lst = new List<String>();
            lst.AddRange(ints);
            return lst;
        }

        public IList<String> getClima()
        {
            String[] ints = { "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max", "9ºC min 20ºC max" };
            List<String> lst = new List<String>();
            lst.AddRange(ints);
            return lst;
        }

        public IList<String> getAltitud()
        {
            String[] ints = { "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m", "3,417 m.s.n.m" };
            List<String> lst = new List<String>();
            lst.AddRange(ints);
            return lst;
        } 
		
        public SampleDataSource()
        {

            this.AllGroups.Add(new SampleDataCommon("Group-1",
                                                "Una maravilla en las profundidades",
                                                "El cañón del Colca cuyo nombre proviene de la palabra aymara Q’ullq’u, es reconocido como el más profundo del planeta con 4,160 mts., así mismo es considerado  una de las maravillas del país y el mundo, conocerlo le hará descubrir un espacio que asombra.",
                                                "ms-appx:///levelzero/images/1.jpg",
                                                "amarillo"));
            this.AllGroups.Add(new SampleDataCommon("Group-2",
                                                    "Dioses convertidos en montañas andinas dan origen al Amazonas",
                                                    "Los andes peruanos se extienden en una extensa franja de Sudamérica, y en el Colca parecen tocarse con las manos, nevados como el Mismi, Hualca Hualca, Bomboya,  Qhehuisha y Sepegrima se muestran como una inmensa muralla ante nuestros ojos, siendo el Mismi el que da origen al Amazonas.",
                                                    "ms-appx:///levelzero/images/2.jpg",
                                                    "verde"));
            this.AllGroups.Add(new SampleDataCommon("Group-3",
                                                    "Rio que se pierde entre las rocas",
                                                    "El rio  Colca sigue un extenso recorrido en el que se hallan remolinos y rápidos, avanza por más de 120 Km hasta llegar al océano pacífico. En 1981 una expedición polaca lo navegó completamente por primera vez.",
                                                    "ms-appx:///levelzero/images/3.jpg",
                                                    "verde"));
            this.AllGroups.Add(new SampleDataCommon("Group-4",
                                                    "Montañas convertidas en tierra cultivable por orden del Inca",
                                                    "La leyenda cuenta que el inca era como un dios que mandaba ordenarse a las piedras y estas lo hacían por si solas, mandó que se armasen las chacras (andenes) que son terrazas en las laderas de las montañas y hoy miles de ellas forman un paisaje bellísimo.",
                                                    "ms-appx:///levelzero/images/4.jpg",
                                                    "azul"));
            this.AllGroups.Add(new SampleDataCommon("Group-5",
                                                    "Vicuñas, Llamas y Alpacas los camélidos de los andes",
                                                    "Camino al Colca se avistan vicuñas silvestres, son reconocidas por  poseer una de las fibras más finas del mundo. La Alpaca es reconocida también por su fina lana y además por su carne, la Llama es un animal de carga que aún sigue recorriendo los caminos del Colca.",
                                                    "ms-appx:///levelzero/images/5.jpg",
                                                    "amarillo"));
            this.AllGroups.Add(new SampleDataCommon("Group-6",
                                                    "El Cóndor: El ave voladora más grande del mundo vigila las profundidades del cañón",
                                                    "El ave emblemática de los andes tiene una envergadura en vuelo  que puede alcanzar los 3.50 mts. y remonta alturas de hasta 7,000 mts. Es el animal más mítico de los andes, tiene una alianza particular con el zorro andino, se dice además que sólo elige una pareja durante toda su vida.",
                                                    "ms-appx:///levelzero/images/6.jpg",
                                                    "azul"));
            this.AllGroups.Add(new SampleDataCommon("Group-7",
                                                    "La montaña de donde salieron los hombres del Colca",
                                                    "En 1586 los Curacas (Jefes andinos) dieron cuenta de que provenían de una montaña que se encontraba en Velille, de cuyo nombre “Collaguata”, es que adoptaron el nombre de Collaguas y por la forma de esta se alargaban las cabezas.",
                                                    "ms-appx:///levelzero/images/7.jpg",
                                                    "amarillo"));
            this.AllGroups.Add(new SampleDataCommon("Group-8",
                                                    "Aguas termales que salen de un valle de fuego",
                                                    "Es un deleite bañarse en las aguas que brotan de la tierra, en contraste con el fresco clima  del Colca, su calor cobija amigablemente, después de un ajetreado día tomar un descanso en ellas resulta reparador.",
                                                    "ms-appx:///levelzero/images/8.jpg",
                                                    "rojo"));
            this.AllGroups.Add(new SampleDataCommon("Group-9",
                                                    "Naciones milenarias se alzan orgullosas: Collaguas y Cabanas",
                                                    "Dos naciones,  una asentada en la parte alta del rio Colca y la otra en la parte baja, mantienen con orgullo su identidad, los Collaguas y los Cabanas se diferenciaron en tiempos antiguos por el alargamiento o achatamiento de sus cabezas, hoy se distinguen en sus sombreros y costumbres.",
                                                    "ms-appx:///levelzero/images/9.jpg",
                                                    "violeta"));
            this.AllGroups.Add(new SampleDataCommon("Group-10",
                                                    "Fiesta nacional danzando el Wititi, patrimonio cultural de la nación",
                                                    "Es la danza más representativa del Colca y tuvo su origen en un acto de protección de las mujeres ante ataques amatorios, donde los hombres disfrazándose con trajes de mujeres escarmentaban a los libertinos, hoy es una danza de amor.",
                                                    "ms-appx:///levelzero/images/10.jpg",
                                                    "azul"));
            this.AllGroups.Add(new SampleDataCommon("Group-11",
                                                    "Iglesias coloniales aún tocan sus campanas llamando a la población",
                                                    "Una iglesia en cada pueblo. Más de veinte de ellas muestran una arquitectura religiosa colonial extraordinaria, aquí no se erigieron iglesias modernas, se prefirió protegerlas y son una puerta al pasado que nos habla de siglos de fe.",
                                                    "ms-appx:///levelzero/images/11.jpg",
                                                    "azul"));
            this.AllGroups.Add(new SampleDataCommon("Group-12",
                                                    "Extraordinarios sitios arqueológicos que muestran el pasado Inca y preinca",
                                                    "En el Colca hay varios sitios arqueológicos, destacan las Cuevas con arte rupestre de Mollepunku, la ciudadela de Paraqra, la de  Uskallacta, Uyo Uyo, Kallimarka y otros.",
                                                    "ms-appx:///levelzero/images/12.jpg",
                                                    "azul"));
            this.AllGroups.Add(new SampleDataCommon("Group-13",
                                                    "Hoteles que se funden con el paisaje",
                                                    "Una importante oferta hotelera de todas las categorías hacen posible que cualquier visitante pueda permanecer en este lugar sin extrañar comodidades ni servicios.",
                                                    "ms-appx:///levelzero/images/13.jpg",
                                                    "rojo"));
            this.AllGroups.Add(new SampleDataCommon("Group-14",
                                                    "Tierra de aventura que te desafía",
                                                    "El Colca  ofrece al buscador de aventura una geografía agreste y un paisaje hermoso, base  para la práctica de diversas actividades deportivas. Su territorio presenta un gran desafío, se pueden realizar caminatas con llamas cargueras, ciclismo, kayac, etc. ",
                                                    "ms-appx:///levelzero/images/14.jpg",
                                                    "amarillo"));
            this.AllGroups.Add(new SampleDataCommon("Group-15",
                                                    "Gente que te abre sus puertas para compartir sus vivencias",
                                                    "El Colca tiene una oferta de servicios de hospedaje y alimentación proporcionados por la misma población, alojarse con ellos nos permite conocer su historia, sus costumbres, apreciar y compartir la sencillez de su vida cotidiana y aportar con nuestras experiencias y consejos a su progreso.",
                                                    "ms-appx:///levelzero/images/15.jpg",
                                                    "violeta"));
            this.AllGroups.Add(new SampleDataCommon("Group-16",
                                                    "Una caminata hacia las profundidades que es única en el mundo",
                                                    "Las dos rutas de treking más importantes del país son camino Inca en el Cusco y las rutas de treking de Cabanaconde, descendiendo hacia las profundidades del cañón se encuentra un oasis (Sangalle)  que nos seduce con su belleza.",
                                                    "ms-appx:///levelzero/images/16.jpg",
                                                    "azul"));
            this.AllGroups.Add(new SampleDataCommon("Group-17",
                                                    "Poblaciones que visten los trajes más bonitos del Perú",
                                                    "Los concursos nacionales de trajes típicos del Perú, han hecho ganador a los vestidos del Colca que son considerados los más bonitos del País. Son ropas coloridas extraordinariamente bordadas por los artesanos del lugar.",
                                                    "ms-appx:///levelzero/images/17.jpg",
                                                    "rojo"));
            this.AllGroups.Add(new SampleDataCommon("Group-18",
                                                    "Manos que bordan miles de arcoíris",
                                                    "Sus artesanos son expertos bordadores, sombreros, carteras, correas, vestidos, etc, muestran la iconografía del lugar a partir de sorprendentes bordados a mano.",
                                                    "ms-appx:///levelzero/images/18.jpg",
                                                    "rojo"));
            this.AllGroups.Add(new SampleDataCommon("Group-19",
                                                    "Pueblos de piedra detenidos en el tiempo",
                                                    "Los pueblos del Colca  aún tienen construcciones de techo y paja, el más bonito de todos es el de Sibayo, si uno lo visita es como viajar al pasado. Sin embargo cada pueblo tiene un encanto especial donde la arquitectura tradicional nos transporta en el tiempo.",
                                                    "ms-appx:///levelzero/images/19.jpg",
                                                    "rojo"));
            this.AllGroups.Add(new SampleDataCommon("Group-20",
                                                    "La cruz del Cóndor el mirador más alto de la tierra.",
                                                    "El mirador de la Cruz del Cóndor permite apreciar la inmensidad de las montañas y la profundidad de la tierra, es muy frecuente avistar en este punto al Cóndor, que majestuoso se pasea en estos insondables abismos.",
                                                    "ms-appx:///levelzero/images/20.jpg",
                                                    "rojo"));
            this.AllGroups.Add(new SampleDataCommon("Group-22",
                                                    "Yanque",
                                                    "Fue la capital de todo el territorio, residencia de los jefes collaguas,  posee una hermosa iglesia colonial, museos, los baños termales de Chacapi, puentes coloniales, sitios arqueológicos, etc. en su plaza principal los jóvenes danzan diariamente.",
                                                    "ms-appx:///levelzero/images/21.jpg",
                                                    "rojo"));
            this.AllGroups.Add(new SampleDataCommon("Group-23",
                                                    "Cabanaconde",
                                                    "Era la capital de la nación Cabana, posee la mejor tierra para la agricultura, en especial para el maíz, por el que son famosos, desde aquí uno puede observar las profundidades del cañón en varios miradores, aquí también se inicia la caminata hacia el fondo del cañón, donde se encuentra un pequeño paraíso que es Sangalle.",
                                                    "ms-appx:///levelzero/images/22.jpg",
                                                    "rojo"));
            this.AllGroups.Add(new SampleDataCommon("Group-24",
                                                    "El Corazón del Colca: Pinchollo",
                                                    "Constituía el límite de las etnias Collagua y Cabana, hay en sus alrededores un Geiser al que llaman “Infiernillo de Puye”, y en su territorio se halla el mirador de la Cruz del Condor  y en un lugar que llaman Yurac  Jurac se puede apreciar nidos de condores.",
                                                     "ms-appx:///levelzero/images/23.jpg",
                                                    "rojo"));
            this.AllGroups.Add(new SampleDataCommon("Group-25",
                                                    "Los castillos encantados: Callalli",
                                                    "Torre Qaqa es su APU (Montaña Sagrada), posee el mejor arte rupestre de la provincia (Cuevas de Mollepunco), es un pueblo que vive de la crianza de camélidos sudamericanos, uno puede realizar aquí turismo vivencial y de aventura.",
                                                    "ms-appx:///levelzero/images/24.jpg",
                                                    "rojo"));
            this.AllGroups.Add(new SampleDataCommon("Group-26",
                                                    "Pueblo de Piedra: Sibayo",
                                                    "El pueblo más tradicional del Colca es Sibayo, se ha preocupado mucho por mantener su identidad arquitectónica, a partir de sus construcciones en piedra, puentes colgantes, miradores, rutas de llamas y otros atractivos,  resulta el más encantador  de todos.",
                                                    "ms-appx:///levelzero/images/24.jpg",
                                                    "rojo"));
            this.AllGroups.Add(new SampleDataCommon("Group-27",
                                                    "La tierra de la esposa del Inca: Coporaque",
                                                    "Las crónicas dicen que el inca se enamoró de una de las hijas del curaca principal de Coporaque, y la hizo su esposa, en su honor mandó construir una casa de cobre, en la actualidad es un bonito pueblo con una gran iglesia colonial, desde aquí uno puede dirigirse hacia Uyo Uyo sitio arqueológico  puesto en valor y de hermoso paisaje.",
                                                    "ms-appx:///levelzero/images/26.jpg",
                                                    "rojo"));
            this.AllGroups.Add(new SampleDataCommon("Group-28",
                                                    "Chivay",
                                                    "Es la capital de la provincia, pueblo base para la visita turística del Colca, posee todos los servicios esenciales, destacan entre sus recursos turísticos las aguas termales de la Calera consideradas las mejores de toda la provincia. Hay aquí sitios arqueológicos y un espléndido camino inca.",
                                                    "ms-appx:///levelzero/images/27.jpg",
                                                    "rojo"));
            this.AllGroups.Add(new SampleDataCommon("Group-29",
                                                    "Canocota",
                                                    "A sus pobladores les dicen Waynalima, y así llaman también a un pequeño cañoncito de extraordinaria belleza, aquí uno puede encontrar Chulpas (construcciones funerarias en piedra), lagunas como Condori e Ipaqota, y sitios arqueológicos como Qoqore.",
                                                    "ms-appx:///levelzero/images/28.jpg",
                                                    "rojo")); 
        }
    }
}
