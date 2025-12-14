using UnityEngine;
using UnityEngine.UI;

namespace Zoo
{
    // Stuurt de acties aan vanuit de UI (Hello / Meat / Leaves / Tricks).
    // Knoppen zijn direct gekoppeld aan de public methods hieronder.
    public class Debugger : MonoBehaviour
    {
        // Inputveld kan in de Inspector geset worden. 
        // Zo niet, wordt het tijdens runtime automatisch opgezocht.
        [SerializeField] private InputField nameInputField;

        // Publieke entrypoints voor de UI-buttons.
        public void OnHello()      => HandleHello();
        public void OnGiveMeat()   => FeedCarnivores();
        public void OnGiveLeaves() => FeedHerbivores();
        public void OnTricks()     => MakeTricks();

        // Zonder naam: alle dieren zeggen hallo.
        // Met naam: alleen het dier dat overeenkomt met de invoer.
        private void HandleHello()
        {
            var animals = FetchAnimals();
            var requestedName = GetRequestedName();
            var normalizedRequest = NormalizeName(requestedName);

            if (string.IsNullOrEmpty(normalizedRequest))
            {
                foreach (var animal in animals) animal.SayHello();
                return;
            }

            var selected = FindAnimalByName(animals, normalizedRequest);
            if (selected != null)
            {
                selected.SayHello();
            }
            else
            {
                Debug.LogWarning(
                    $"Geen dier gevonden met de naam '{requestedName}'. " +
                    "Probeer de naam van het dier zelf of het type (bijv. 'lion').");
            }
        }

        // Laat alleen dieren die vlees eten reageren.
        private void FeedCarnivores()
        {
            foreach (var animal in FetchAnimals())
                if (animal is ICarnivore c) c.EatMeat();
        }

        // Laat alleen dieren die bladeren eten reageren.
        private void FeedHerbivores()
        {
            foreach (var animal in FetchAnimals())
                if (animal is IHerbivore h) h.EatLeaves();
        }

        // Laat alleen dieren met een trick die uitvoeren.
        private void MakeTricks()
        {
            foreach (var animal in FetchAnimals())
                if (animal is ITrickPerformer t) t.PerformTrick();
        }

        // Haalt alle dieren uit de actieve scene op.
        private Animal[] FetchAnimals() => FindObjectsOfType<Animal>();

        // Zoekt een dier op naam, objectnaam of type (niet hoofdlettergevoelig).
        private Animal FindAnimalByName(Animal[] animals, string normalizedRequest)
        {
            foreach (var animal in animals)
                if (MatchesName(animal, normalizedRequest))
                    return animal;
            return null;
        }

        // Hulpmethodes voor naamherkenning van dieren.
        // Zorgt dat invoer niet hoofdlettergevoelig is en ook werkt op type of objectnamen.
        private bool MatchesName(Animal animal, string normalizedRequest)
        {
            if (string.IsNullOrEmpty(normalizedRequest)) return false;

            if (NormalizeName(animal.AnimalName)      == normalizedRequest) return true;
            if (NormalizeName(animal.gameObject.name) == normalizedRequest) return true;
            if (NormalizeName(animal.GetType().Name)  == normalizedRequest) return true;

            return false;
        }

        private string GetRequestedName()
        {
            var field = EnsureNameInput();
            return field == null ? string.Empty : field.text.Trim();
        }

        // Maakt invoer en namen consistent, verwijdert “(Clone)” en hoofdletters.
        private static string NormalizeName(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return string.Empty;
            return value.Replace("(Clone)", string.Empty).Trim().ToLowerInvariant();
        }

        // Probeert de referentie te vullen als die niet in de Inspector is geset.
        private InputField EnsureNameInput()
        {
            if (nameInputField == null)
                nameInputField = FindObjectOfType<InputField>();
            return nameInputField;
        }
    }
}
