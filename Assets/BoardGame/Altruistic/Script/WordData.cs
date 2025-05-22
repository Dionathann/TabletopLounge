using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Altruistic Word List", menuName = "Altruistic Word/WordList")]
public class WordData : ScriptableObject
{
    public List<string> wordsListIndonesia = new List<string>();
    public List<string> wordsListEnglish = new List<string>();

    public void ClearWords()
    {
        wordsListIndonesia.Clear();
        wordsListEnglish.Clear();
    }

    public void AddWordsManually()
    {
        wordsListIndonesia.AddRange(new List<string> {
            //buah
            "Apel", "Pisang", "Jeruk", "Mangga", "Anggur",
            "Nanas", "Semangka", "Melon", "Strawberi", "Kiwi",

            //sayur
            "Wortel", "Bayam", "Kangkung", "Brokoli", "Kubis",
            "Timun", "Tomat", "Terong", "Buncis", "Labu",

            //kendaraan
            "Mobil", "Motor", "Sepeda", "Bus", "Truk",
            "Kereta", "Kuda", "Kapal", "Helikopter", "Sepeda Roda 1",

            //animal
            "Gajah", "Elang", "Ular", "Kangguru", "Ikan",
            "Kura-kura", "Kelelawar", "Gurita", "Kucing", "Semut",

            //tempat
            "Gunung", "Pantai", "Hutan", "Pasar", "Sekolah",
            "Bandara", "Desa", "Kota", "Gurun", "Kutub Utara",

            //
            "Dokter", "Petani", "Pilot", "Guru", "Pemadam Kebakaran",
            "Programmer", "Seniman", "Pengacara", "Koki", "Astronot",

            //
            "Tsunami", "Hujan", "Badai", "Salju", "Gempa Bumi",
            "Angin Topan", "Kekeringan", "Letusan Gunung", "Kabut", "Pelangi",

            //
            "Rumah Sakit", "Sekolah", "Bandara", "Universitas", "Stasiun",
            "Perpustakaan", "Kantor Polisi", "Taman", "Mall", "Museum",

            //
            "Monitor", "Keyboard", "Mouse", "Internet", "Printer",
            "Scanner", "Speaker", "Webcam", "Harddisk", "Motherboard",

            //
            "Air Putih", "Teh", "Kopi", "Jus Jeruk", "Susu",
            "Soda", "Sirup", "Es Kelapa", "Cokelat Panas", "Lemon Tea",

            //
            "Gitar", "Piano", "Drum", "Biola", "Saxofon",
            "Flute", "Terompet", "Harmonika", "Bass", "Tamborin",

            //
            "Mawar", "Melati", "Kaktus", "Bambu", "Padi",
            "Teratai", "Anggrek", "Lidah Buaya", "Pohon Beringin", "Rumput",

            //
            "Kursi", "Meja", "Kasur", "Kipas", "Lemari",
            "Lampu", "TV", "Kulkas", "Kompor", "Jam Dinding",

            "Menara Eiffel", "Tembok Besar Cina", "Piramida Giza", "Patung Liberty", "Menara Pisa",
            "Colosseum", "Taj Mahal", "Machu Picchu", "Gunung Fuji", "Air Terjun Niagara"
        });

        wordsListEnglish.AddRange(new List<string> {
            //buah
            "Apple", "Banana", "Orange", "Mango", "Grape",
            "Pineapple", "Watermelon", "Melon", "Strawberry", "Kiwi",

            //sayur
            "Carrot", "Spinach", "Water Spinach", "Broccoli", "Cabbage",
            "Cucumber", "Tomato", "Eggplant", "Green Beans", "Pumpkin",

            //kendaraan
            "Car", "Motorcycle", "Bicycle", "Bus", "Truck",
            "Train", "Airplane", "Ship", "Helicopter", "Unicycle",

            //animal
            "Elephant", "Eagle", "Snake", "Kangaroo", "Whale",
            "Turtle", "Bat", "Octopus", "Cat", "Ant",

            //Tempat
            "Mountain", "Beach", "Forest", "Market", "School",
            "Airport", "Village", "City", "Desert", "North Pole",

            //
            "Doctor", "Farmer", "Pilot", "Teacher", "Firefighter",
            "Programmer", "Artist", "Lawyer", "Chef", "Astronaut",
            
            //
            "Tsunami", "Rain", "Storm", "Snow", "Earthquake",
            "Hurricane", "Drought", "Volcanic Eruption", "Fog", "Rainbow",

            //
            "Hospital", "School", "Airport", "University", "Train Station",
            "Library", "Police Station", "Park", "Mall", "Museum",

            //
            "Monitor", "Keyboard", "Mouse", "Internet", "Printer",
            "Scanner", "Speaker", "Webcam", "Hard Drive", "Motherboard",

            //
            "Water", "Tea", "Coffee", "Orange Juice", "Milk",
            "Soda", "Syrup", "Coconut Ice", "Hot Chocolate", "Lemon Tea",

            //
            "Guitar", "Piano", "Drums", "Violin", "Saxophone",
            "Flute", "Trumpet", "Harmonica", "Bass", "Tambourine",

            //
            "Rose", "Jasmine", "Cactus", "Bamboo", "Rice",
            "Lotus", "Orchid", "Aloe Vera", "Banyan Tree", "Grass",

            //
            "Chair", "Table", "Mattress", "Fan", "Wardrobe",
            "Lamp", "TV", "Fridge", "Stove", "Wall Clock",

            //
            "Eiffel Tower", "Great Wall of China", "Pyramids of Giza", "Statue of Liberty", "Leaning Tower of Pisa",
            "Colosseum", "Taj Mahal", "Machu Picchu", "Mount Fuji", "Niagara Falls"
        });
    }
}
