using System;
using System.Collections.Generic;
using System.Linq;
using StartEndStationItem = System.Tuple<string, string>;
using StartEndStationMap = System.Collections.Generic.Dictionary<string, string>;

namespace HelpHassMeetFriend
{
    public class RouteFinder
    {
        private const string HassStartStation = "H";
        private const string HassEndStation = "L";
        private readonly List<StartEndStationMap> maps = new List<StartEndStationMap>();

        private bool TryGetStationsFromLine(string enteredLine, out StartEndStationItem result)
        {
            result = null;

            string[] stationsMap = enteredLine.Trim().Split(new char[] { ' ', '-' });

            if (stationsMap.Length == 2)
            {
                result = new StartEndStationItem(stationsMap[0], stationsMap[1]);
            }
            return result != null;
        }

        private LinkedList<StartEndStationItem> FindShortestRoute(List<StartEndStationMap> maps)
        {
            if (maps == null || maps.Count == 0)
            {
                return null;
            }

            var fastestRoute = new LinkedList<StartEndStationItem>();

            int? stationsCount = null;

            foreach (var map in maps)
            {
                var result = new LinkedList<StartEndStationItem>();

                var currentLinked = result.AddFirst(new StartEndStationItem(HassStartStation, map[HassStartStation]));

                var currentIndex = 0;

                //// There alwasy be a valid route to the last station.
                while (currentIndex < map.Count && !this.HasMatch(result))
                {
                    var keyPair = map.Skip(currentIndex++).Take(1).First();

                    if (keyPair.Key == currentLinked.Value.Item2)
                    {
                        currentLinked = result.AddAfter(currentLinked, new StartEndStationItem(keyPair.Key, map[keyPair.Key]));
                        currentIndex = 0;
                    }
                }
                if (this.HasMatch(result) && (!stationsCount.HasValue || stationsCount > result.Count))
                {
                    fastestRoute = result;

                    stationsCount = result.Count;
                }
            }
            return fastestRoute;
        }

        private bool HasMatch(LinkedList<StartEndStationItem> result)
        {
            if (result.Count == 0)
            {
                return false;
            }
            return result.First.Value.Item1 == HassStartStation && result.Last.Value.Item2 == HassEndStation;
        }

        private IEnumerable<string> GetRoutes(LinkedList<StartEndStationItem> result)
        {
            if (result == null || result.Count == 0)
            {
                yield return "Hass will stay alone.";
            }
            else
            {
                var node = result.First;

                while (node != null)
                {
                    yield return node.Value.Item1;

                    yield return " ";

                    if (node == result.Last)
                    {
                        yield return node.Value.Item2;
                    }
                    node = node.Next;
                }
            }
        }

        public IEnumerable<string> GetRoutes()
        {
            LinkedList<StartEndStationItem> result = FindShortestRoute(maps);

            return this.GetRoutes(result);
        }

        public bool TrySetStationsFromLine(string line)
        {
            StartEndStationItem stations;
            if (this.TryGetStationsFromLine(line, out stations))
            {
                if (maps.Count == 0 || maps.Any(s => s.ContainsKey(stations.Item1)))
                {
                    this.CopyRoutes(stations);
                }
                else
                {
                    this.maps.ForEach(s => s.Add(stations.Item1, stations.Item2));
                }
                return true;
            }
            return false;
        }

        private void CopyRoutes(StartEndStationItem stationsItem)
        {
            var newMap = new StartEndStationMap { { stationsItem.Item1, stationsItem.Item2 } };
            this.maps.ForEach(s =>
            {
                foreach (var key in s.Keys.ToList())
                {
                    if (!newMap.ContainsKey(key))
                    {
                        newMap.Add(key, s[key]);
                    }
                }
            });
            this.maps.Add(newMap);
        }
    }
}
