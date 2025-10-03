namespace M__31_1_Azaryan_TorusAI.NeuroNet
{
  enum MemoryMode //режим работы памяти 
    {
        GET, // получение 
        SET, // сохранение 
        INIT // инициализация 
    }

    enum NeuronType // тип нейрона 
    {
        Hidden, // скрытый 
        Output  // выходной 
    }

    enum NetworkMode // режим работы сети 
    {
        Train, // обучение  
        Test, // проверка
        Demo // распознование 
    }
}
