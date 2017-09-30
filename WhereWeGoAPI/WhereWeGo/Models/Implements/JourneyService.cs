using System;
using System.Collections.Generic;
using System.Linq;
using WhereWeGo.DTOs;
using WhereWeGo.Models.Interfaces;

namespace WhereWeGo.Models.Implements
{
    public class JourneyService : IJourneyService
    {
        private IEnumerable<Traveling> _favorit;
        private Random random = new Random();

        public JourneyService()
        {
            int milSecond = DateTime.Now.Millisecond;
            this._favorit = new List<Traveling> {
                //德国
                new Traveling{
                    From ="Berlin Hbf", From_Code="ST_E0203JK4",
                    To ="München Hbf", To_Code = "ST_EMYR64OX",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price =210   },
                new Traveling {
                    From ="Frankfurt(Main)Hbf", From_Code ="ST_LYKXO1K1",
                    To ="München Hbf", To_Code = "ST_EMYR64OX",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price = 380 },
                new Traveling {
                    From ="Frankfurt(M) Flughafen", From_Code = "ST_D8N9YK5N",
                    To ="München Hbf", To_Code="ST_EMYR64OX",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price = 320 },
                new Traveling {
                    From ="Frankfurt(Main)Hbf", From_Code = "ST_LYKXO1K1",
                    To ="Stuttgart Hbf", To_Code = "ST_EZVGOKVW",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price = 310 },
                new Traveling {
                    From ="Frankfurt(Main)Hbf", From_Code = "ST_LYKXO1K1",
                    To ="Köln Hbf", To_Code = "ST_EJ06PO45",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price = 370 },
                new Traveling {
                    From ="Frankfurt(Main)Hbf", From_Code = "ST_LYKXO1K1",
                    To ="Düsseldorf Hbf", To_Code = "ST_EJ06PO45",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price = 310 },
                new Traveling {
                    From ="Frankfurt(Main)Hbf", From_Code = "ST_LYKXO1K1",
                    To ="Berlin Hbf", To_Code = "ST_E0203JK4",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price = 320 },
                new Traveling {
                    From ="Berlin Hbf", From_Code = "ST_E0203JK4",
                    To ="Hamburg Hbf", To_Code = "ST_EMYR64R3",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price = 390 },

                //意大利
                new Traveling {
                    From ="Roma Termini", From_Code = "ST_D8NNN9ZK",
                    To ="Venezia S. Lucia", To_Code = "ST_ENZZ7QVN",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price = 100 },
                new Traveling {
                    From ="Roma Termini", From_Code = "ST_D8NNN9ZK",
                    To ="Milano Centrale", To_Code = "ST_EZVVG1X5",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price = 340 },

                //跨国线路-德国出发
                new Traveling {
                    From ="Frankfurt(Main)Hbf", From_Code = "ST_LYKXO1K1",
                    To ="Paris Est", To_Code = "ST_DQM28J3P",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price = 310 },
                new Traveling {
                    From ="Hamburg Hbf", From_Code = "ST_EMYR64R3",
                    To ="Amsterdam Centraal", To_Code = "ST_DQM28J3P",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price = 800 },
                new Traveling {
                    From ="Frankfurt(Main)Hbf", From_Code = "ST_LYKXO1K1",
                    To ="Amsterdam Centraal", To_Code = "ST_DQM28J3P",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price = 300 },
                new Traveling {
                    From ="Frankfurt(Main)Hbf", From_Code = "ST_LYKXO1K1",
                    To ="Bruxelles-Midi", To_Code = "ST_EG62437J",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price = 320 },
                new Traveling {
                    From ="München Hbf", From_Code = "ST_EMYR64OX",
                    To ="Wien Hbf", To_Code = "ST_EZVGJ2KG",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price = 100 },
                new Traveling {
                    From ="München Hbf", From_Code = "ST_EMYR64OX",
                    To ="Praha hl.n.(Prag HBF)", To_Code = "ST_L2JGR0QL",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price = 350 },
                new Traveling {
                    From ="München Hbf", From_Code = "ST_EMYR64OX",
                    To ="Venezia S. Lucia", To_Code = "ST_ENZZ7QVN",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price = 700 },
            };
        }

        public object Random { get; private set; }

        public void SetTravelings(IEnumerable<Traveling> ieTr)
        {
            this._favorit = ieTr;
        }

        public Traveling GetRandomTraveling()
        {
            Traveling result = null;


            int num = random.Next() % this._favorit.Count();

            result = this._favorit.ElementAt(num);

            return result;
        }
    }
}