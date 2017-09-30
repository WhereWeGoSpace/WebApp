using System;
using System.Collections.Generic;
using System.Linq;
using WhereWeGoAPI.DTOs;
using WhereWeGoAPI.Models.Interfaces;

namespace WhereWeGoAPI.Models.Implements
{
    public class JourneyService : IJourneyService
    {
        private IEnumerable<Traveling> _favorit;
        private Random random = new Random();

        public JourneyService()
        {
            int milSecond = DateTime.Now.Millisecond;
            this._favorit = new List<Traveling> {
                //法国出发
                new Traveling{
                    From="PARIS GARE DE LYON", From_Code="ST_EZVOJP9W",
                    To="Milano Centrale",To_Code="ST_EZVVG1X5",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price=388
                },
                new Traveling {
                    From="Paris Est", From_Code="ST_DQM28J3P",
                    To="Frankfurt(Main)Hbf",To_Code="ST_LYKXO1K1",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price=388
                },
                new Traveling {
                    From="Marseille-St-Charles", From_Code="ST_DKR6X1Y6",
                    To="Milano Centrale",To_Code="ST_EZVVG1X5",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price=388
                },
                new Traveling {
                    From="Nice Ville", From_Code="ST_LYKO4G43",
                    To="Milano Centralee",To_Code="ST_EZVVG1X5",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price=388
                },

                //荷兰、比利时、卢森堡出发
                new Traveling {
                    From="Amsterdam Centraal", From_Code="ST_DQM28J3P",
                    To="Frankfurt(Main)Hbf",To_Code="ST_LYKXO1K1",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price=388
                },
                new Traveling {
                    From="Bruxelles-Mid", From_Code="ST_EG62437J",
                    To="Frankfurt(Main)Hbf",To_Code="ST_LYKXO1K1",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price=388
                },

                //瑞士出发
                new Traveling {
                    From="Zürich HB", From_Code="ST_EZVVZO2X",
                    To="Milano Centrale",To_Code="ST_EZVVG1X5",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price=388
                },
                new Traveling {
                    From="Geneve", From_Code="ST_E7GGK700",
                    To="Milano Centrale",To_Code="ST_EZVVG1X5",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price=388
                },
                new Traveling {
                    From="Basel SBB", From_Code="ST_E5KKZ82Y",
                    To="Milano Centrale",To_Code="ST_EZVVG1X5",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price=388
                },
                new Traveling {
                    From="Luzern", From_Code="ST_EZVVZMZG",
                    To="Milano Centrale",To_Code="ST_EZVVG1X5",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price=388
                },
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