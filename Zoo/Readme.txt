# Zoo Game – Unity ING Opdracht

### Opdracht
Deze Unity opdracht draaide om het verbeteren van een bestaande “Zoo” game door de code te refactoren en uit te breiden.  
De doelen waren:
- De game functioneel afmaken.  
- De code structureren met overerving en interfaces.  
- Twee nieuwe dieren toevoegen.  

---

### Refactor uitleg
Tijdens het afronden van de opdracht heb ik de codebase opgeschoond, gestroomlijnd en consistenter gemaakt:

- Nieuwe **basisklasse `Animal`** gemaakt met functies voor `Speak()`, `SayHello()` en `SetAnimalName()`.  
- Bestaande dieren (`Lion`, `Tiger`, `Pig`, `Hippo`, `Zebra`) laten **overerven van `Animal`** en alleen hun eigen gedrag implementeren.  
- **Interfaces** toegevoegd (`IHerbivore`, `ICarnivore`, `ITrickPerformer`) om duidelijk gedrag te scheiden.  
- Hierdoor is het nu onmogelijk dat een zebra bijvoorbeeld `EatMeat()` kan aanroepen.  
- De **`Spawner`** refactored zodat die via een generieke helper dieren spawnt op basis van prefab + naam.  
- De **`Debugger`** verwerkt nu de echte UI-knoppen en voert acties uit op de juiste dieren.

---

### Nieuwe dieren
Twee extra dieren toegevoegd met eigen gedrag, sprites en trick:
- **Giraffe (Grace)** eet bladeren en strekt haar nek als trick.  
- **Monkey (Momo)** eet fruit en slingert als trick.  

Beide zijn toegevoegd aan de spawner en bewegen mee met de bestaande dieren.  

---

### Functionaliteit
- **Give Meat:** Alleen carnivoren reageren.  
- **Give Leaves:** Alleen herbivoren reageren.  
- **Tricks:** Alleen dieren met een trick voeren hun animatie uit.  
- **Hello:**  
  - Zonder naam, alle dieren zeggen hallo.  
  - Met naam of diersoort (zoals *"lion"*, *"zebra"*, *"monkey"*) alleen dat specifieke dier reageert.  
  - Case-insensitive invoer en herkenning op naam, type of objectnaam.  

---

### Visuals & Assets
- Nieuwe sprites toegevoegd voor **Monkey** en **Giraffe** in `Assets/Sprites`.  
- Prefabs aangemaakt en gekoppeld aan de juiste componenten in de scene.  
- Nieuwe dieren (Giraffe en Monkey) zijn gebaseerd op een gekopieerde Zebra prefab, vervolgens aangepast met eigen sprite en gedrag.

---

### Opmerkingen
Dit was mijn eerste Unity project.  
Ik heb de opdracht gebruikt om te leren werken met:
- Objectgeorienteerd programmeren in C#  
- Interfaces en overerving  
- Unity prefabs, coroutines en UI interactie  

---

### Resultaat
Het project is nu volledig speelbaar met alle opdrachtfeatures en twee extra dieren.  
De code is opgeschoond, uitbreidbaar en gebruiksklaar voor verdere iteraties.
