using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class PunchedEnemyEventArgs : EventArgs // jak robisz swoje skrypty ktore przechowuja Ci dane o evencie to musisz dziedziczyc po EventArgs
    {
        public GameObject PunchedEnemy { get; }  // to sie nazywa hermetyzacja, nie mozesz zmienic tej zmiennej na przyklad w skrypcie enemy moving bo to zapobiegnie
        public GameObject Attacker { get; }
        public PunchedEnemyEventArgs(GameObject attacker, GameObject punchedEnemy)
        {
            Attacker = attacker;
            PunchedEnemy = punchedEnemy;
        }

        // to jest wlasciwosc (PROPERTY), dzieki niej mozesz:
        // - decydowac co sie ma stac gdy pobieramy / ustawiamy wartosc
        // - maszi nformacje gdzie jst uzywana i ile razy (pisze wyzej 1 odwolanie, a w przypadku pól nie)
        // - to dzia³a dokladnie jak ZMIENNA na przyklad ta na dole _player, _force itd itp. 
        // - mozesz sprecyzowac by na przyklad set (czyli ustawianie wartosci by³ prywatny, wiec wtedy 
        // tylko wewnatrz tej klasy mozesz zmienic jego wartosc ALE mozesz pobrac wartosc gdzes indziej 
    }
}