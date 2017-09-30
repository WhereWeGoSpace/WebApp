using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using WhereWeGoAPI.DTOs;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Requests;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Search;
using WhereWeGoAPI.Models.GrailTravel.SDK;
using WhereWeGoAPI.Models.Interfaces;

namespace WhereWeGoAPI.Models.Implements
{
    public class JourneyService : IJourneyService
    {
        private IEnumerable<Traveling> _favorit;
        private Random random = new Random();
        private IDetieClient _client = null;

        public JourneyService()
            : this(new DetieClient())
        {
        }

        public JourneyService(IDetieClient client)
        {
            this._client = client;
            int milSecond = DateTime.Now.Millisecond;
            this._favorit = new List<Traveling> {
                //法国出发
                new Traveling{
                    From="PARIS GARE DE LYON", From_Code="ST_EZVOJP9W",
                    To="Milano Centrale",To_Code="ST_EZVVG1X5",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price=382
                },
                new Traveling {
                    From="Paris Est", From_Code="ST_DQM28J3P",
                    To="Frankfurt(Main)Hbf",To_Code="ST_LYKXO1K1",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price=188
                },
                new Traveling {
                    From="Marseille-St-Charles", From_Code="ST_DKR6X1Y6",
                    To="Milano Centrale",To_Code="ST_EZVVG1X5",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price=328
                },
                new Traveling {
                    From="Nice Ville", From_Code="ST_LYKO4G43",
                    To="Milano Centralee",To_Code="ST_EZVVG1X5",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price=288
                },

                //荷兰、比利时、卢森堡出发
                new Traveling {
                    From="Amsterdam Centraal", From_Code="ST_DQM28J3P",
                    To="Frankfurt(Main)Hbf",To_Code="ST_LYKXO1K1",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price=348
                },
                new Traveling {
                    From="Bruxelles-Mid", From_Code="ST_EG62437J",
                    To="Frankfurt(Main)Hbf",To_Code="ST_LYKXO1K1",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price=324
                },

                //瑞士出发
                new Traveling {
                    From="Zürich HB", From_Code="ST_EZVVZO2X",
                    To="Milano Centrale",To_Code="ST_EZVVG1X5",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price=123
                },
                new Traveling {
                    From="Geneve", From_Code="ST_E7GGK700",
                    To="Milano Centrale",To_Code="ST_EZVVG1X5",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price=323
                },
                new Traveling {
                    From="Basel SBB", From_Code="ST_E5KKZ82Y",
                    To="Milano Centrale",To_Code="ST_EZVVG1X5",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price=188
                },
                new Traveling {
                    From="Luzern", From_Code="ST_EZVVZMZG",
                    To="Milano Centrale",To_Code="ST_EZVVG1X5",
                    Date = DateTime.Now.Add(TimeSpan.FromDays(random.Next()%7)),
                    Price=228
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

            var searchResult = GetSearchResult(result.From_Code, result.To_Code);
            var searchRoute = JsonConvert.DeserializeObject<List<SearchResponse>>(searchResult);
            if (searchResult == null || searchResult.Count() == 0)
                throw new Exception("There is no 車次");

            return result;
        }

        private String GetSearchResult(string from_code, string to_code)
        {
            var searchReqeust = new SearchRequest
            {
                StartStationCode = from_code,
                DestinationStationCode = to_code,
                StartTime = DateTime.Now.AddDays(20),
                NumberOfAdult = 1,
                NumberOfChildren = 0
            };

            //Act
            var asyncKey = _client.Search(searchReqeust);

            return _client.Search_Async(asyncKey);
        }
    }
}