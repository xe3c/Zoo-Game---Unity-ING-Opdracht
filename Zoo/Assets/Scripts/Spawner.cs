using UnityEngine;

namespace Zoo
{
    // Spawner zorgt dat alle dieren automatisch in de scene geplaatst worden.
    // Dit script maakt gebruik van een generieke methode om herhaling te voorkomen
    // (in de oude versie werden alle dieren apart geinstantieerd met bijna dezelfde code)
    class Spawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject lion, hippo, pig, tiger, zebra, giraffe, monkey;

        // Start wordt een keer aangeroepen wanneer de scene geladen wordt
        // Hier worden alle dieren gespawned en krijgen ze meteen een naam.
        private void Start()
        {
            SpawnAnimal<Lion>(lion, "henk");
            SpawnAnimal<Hippo>(hippo, "elsa");
            SpawnAnimal<Pig>(pig, "dora");
            SpawnAnimal<Tiger>(tiger, "wally");
            SpawnAnimal<Zebra>(zebra, "marty");
            SpawnAnimal<Giraffe>(giraffe, "grace");
            SpawnAnimal<Monkey>(monkey, "momo");
        }

        // Deze methode maakt een instantie van het opgegeven dier aan.
        // Door generics te gebruiken (<T>) is de code flexibel en herbruikbaar voor elk type dier.
        // Hierdoor hoeft nieuw gedrag niet meer apart gekopieerd te worden.
        private T SpawnAnimal<T>(GameObject prefab, string animalName) where T : Animal
        {   
            // Controleer of de prefab aanwezig is, zodat er geen null-fout optreedt.
            if (prefab == null)
            {
                Debug.LogWarning($"Missing prefab for {typeof(T).Name}");
                return null;
            }

            // Geef het dier een naam via de functie in Animal.cs.
            T animal = Instantiate(prefab, transform).GetComponent<T>();
            if (animal != null)
            {
                animal.SetAnimalName(animalName);
            }

            return animal;
        }
    }
}
