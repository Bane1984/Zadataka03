## Zadatak za vježbu I - 05.02.2019

Napraviti ASP.NET Core WebAPI aplikaciju koja služi za evidenciju uređaja i osoba koji ih koriste. Modele definisati poštujući sledeća pravila:

* Svaka osoba ima ime i prezime
* Svaka osoba se nalazi u određenoj kancelariji
* Svaka kancelarija ima svoj opis (npr „Sala za sastanke“, „Marketing sektor“ i slično)
* Osoba se može nalaziti samo u jednoj kancelariji, u svakoj kancelariji se nalazi po više osoba
* Jedan uređaj može biti korišćen od strane samo jedne osobe u jednom momentu
* Jedna osoba može koristiti više uređaja
* Moguće je promijeniti podatak o tome koja osoba koristi neki uređaj
* Moguće je imati uvid u to kada je koja osoba koristila koji uređaj (u periodu od-do)

Potrebno je da aplikacija ima poseban kontroler za svaki od entiteta, pomoću kog je moguće izvršiti sledeće akcije:

* [HttpGet] Get: Akcija koja vraća listu svih entiteta
* [HttpGet] Get/{id}: Akcija koja vraća samo entitet koji ima dati ID
* [HttpPost] Post: Akcija koja upisuje novi entitet u bazu
* [HttpPut] Put/{id}: Akcija koja mijenja postojeći entitet koji ima dati ID
* [HttpDelete] Delete/{id}: Akcija koja briše entitet koji ima dati ID
* [HttpGet] Search: Akcija koja pretražuje entitete po određenim kriterijumima, koje ćete odrediti sami (npr. naziv entiteta, kancelarija u kojoj se neko nalazi, osoba koja koristi neki uređaj, vremenski period za koji je uređaj bio korišćen itd.)

Za ovaj zadatak napraviti novu ASP.NET Core aplikaciju. Integrisati Swagger. Sve javne metode moraju imati XML dokumentaciju. Potrebno je da kod sadrži komentare koji objašnjavaju šta je šta. Koristiti Entity Framework Core. Za modeliranje baze koristiti Code First pristup i migracije. Odrađeni zadatak postaviti na svoj github repozitorijum.
