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
        "Apel", "Bola", "Cinta", "Dunia", "Elang", "Fisik", "Gajah", "Hutan", "Ikan", "Jalan",

        "Kuda", "Laut", "Matahari", "Naga", "Ombak", "Pohon", "Rumah", "Sungai", "Taman", "Ular",

        "Vas", "Warna", "Xilofon", "Yakin", "Zebra", "Anjing", "Bulan", "Cerah", "Damai", "Emas",

        "Fantasi", "Garam", "Harapan", "Ilusi", "Jendela", "Kaki", "Lilin", "Mentari", "Nanas", "Orang",

        "Perahu", "Raja", "Ratu", "Sapi", "Tarian", "Uang", "Warna-Warni", "X-Ray", "Yoyo", "Zaitun",

        "Awan", "Bintang", "Cahaya", "Doa", "Egois", "Fauna", "Gitar", "Hari", "Indah", "Jari", 
            
        "Kaca", "Lampu", "Merah", "Nasi", "Otak", "Pintu", "Permainan", "Rumput", "Sinar", "Tubuh",
        
        "Udara", "Ventilasi", "Waktu", "Dompet", "Ambulans", "Zodiak", "Ayah", "Belajar", "Cita-Cita", "Dosen",
            
        "Edukasi", "Film", "Guru", "Hidup", "Ilmu", "Jembatan", "Kasih", "LautBiru", "Musik", "Negeri",
            
        "OrangTua", "Pahlawan", "Kabel", "RumahSakit", "Senyum", "Teman", "Universitas", "Vokal", "Warna Dasar", "Tikus",
            
        "Keyboard", "Poster", "Air", "Berani", "Cahaya", "Damai", "Energi", "Fiksi", "Gelas", "Harimau",
            
        "Indera", "Jatuh", "Kasur", "Lembut", "Mimpi", "Nasib", "Orkestra", "Pesawat", "Kereta", "Robot",
            
        "Gunung", "Tenda", "Sikat Gigi", "Vaksin", "Wajah", "Komik", "Yakin", "Tas", "Angin", "Bunga",
            
        "Cerita", "Astronot", "Elektron", "Oksigen", "Gembira", "Youtube", "Ide", "Jemari", "Keajaiban", "Lagu",
        
        "Mata", "Benua", "Gravitasi", "Polusi", "Rasa", "Senja", "Hip-Hop", "Uang", "Programmer", "Novel"
        
        });

        wordsListEnglish.AddRange(new List<string> {
        "Apple", "Ball", "Love", "World", "Eagle", "Physique", "Elephant", "Forest", "Fish", "Road",
            
        "Horse", "Ocean", "Sun", "Dragon", "Wave", "Tree", "House", "River", "Garden", "Snake",
            
        "Vase", "Color", "Xylophone", "Sure", "Zebra", "Dog", "Moon", "Bright", "Peace", "Gold",

        "Fantasy", "Salt", "Hope", "Illusion", "Window", "Foot", "Candle", "Sunshine", "Pineapple", "Person",
            
        "Boat", "King", "Queen", "Cow", "Dance", "Money", "Colorful", "X-Ray", "YoYo", "Olive",
            
        "Cloud", "Star", "Light", "Prayer", "Selfish", "Fauna", "Guitar", "Day", "Beautiful", "Finger",

        "Glass", "Lamp", "Red", "Rice", "Brain", "Door", "Game", "Grass", "Ray", "Body",

        "Air", "Ventilation", "Time", "Wallet", "Ambulance", "Zodiac", "Father", "Study", "Goal", "Teacher",
            
        "Education", "Movie", "Teacher", "Life", "Science", "Bridge", "Love", "BlueSea", "Music", "Country",
            
        "Parent", "Hero", "Cable", "Hospital", "Smile", "Friend", "University", "Vocal", "PrimaryColor", "Mouse",

        "Keyboard", "Poster", "Water", "Brave", "Light", "Peace", "Energy", "Fiction", "Glass", "Tiger",
            
        "Senses", "Fall", "Bed", "Soft", "Dream", "Destiny", "Orchestra", "Airplane", "Train", "Robot",
            
        "Mountain", "Tent", "Tooth Brush", "Vaccine", "Face", "Comic", "Sure", "Bag", "Wind", "Flower",
            
        "Story", "Astronaut", "Electron", "Oxygen", "Joy", "Youtube", "Idea", "Fingers", "Miracle", "Song",

        "Eye", "Continent", "Gravity", "Polution", "Taste", "Sunset", "Hip-Hop", "Money", "Programmer", "Novel"
});
    }
}
