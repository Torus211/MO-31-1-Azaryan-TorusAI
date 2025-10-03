using System;
using System.IO;
using System.Windows.Forms;
using M__31_1_Azaryan_TorusAI.NeuroNet;

namespace M__31_1_Azaryan_TorusAI.NeuroNet
{
    abstract class Layer
    {
        protected string layerName;
        string pathDirWeights;
        string pathFileWeights;
        protected int numberOfNeurons;
        protected int numberOfPreviousNeurons;
        protected const double learningRate = 0.060;
        protected const double momentum = 0.050d;
        protected double[,] lastDeltaWeights;
        protected Neuron[] neurons;

        public Neuron[] Neurons { get => neurons; set => neurons = value; }

        public double[] Data // input data
        {
            set
            {
                for (int i = 0; i < numberOfNeurons; i++)
                {
                    Neurons[i].Activator(value);
                }
            }
        }

        protected Layer(int non, int nopn, NeuronType nt, string nmLayer)
        {
            numberOfNeurons = non;
            numberOfPreviousNeurons = nopn;
            Neurons = new Neuron[non];
            layerName = nmLayer;
            pathDirWeights = AppDomain.CurrentDomain + "memory\\";
            pathFileWeights = pathDirWeights + layerName + "_memory.csv";

            double[,] Weights;

            if (File.Exists(pathFileWeights))
            {
               Weights = WeightInitialize(MemoryMode.GET, pathFileWeights);
            }
            else
            {
                Directory.CreateDirectory(pathFileWeights);
                Weights = WeightInitialize(MemoryMode.INIT, pathFileWeights);
            }

            lastDeltaWeights = new double[non, nopn + 1];
            for (int i = 0; i < non; i++)
            {
                double[] tmpWeights = new double[nopn + 1];
                for (int j = 0; j < nopn + 1; j++)
                {
                    tmpWeights[j] = Weights[i, j];
                }
                Neurons[i] = new Neuron(tmpWeights, nt);
            }
        }

        public double[,] WeightInitialize(MemoryMode memoryMode, string path)
        {
            char[] separator = new char[] { ';', ' ' };
            string tmpString;
            string[] tmpWeightsString;
            double[,] weights = new double[numberOfNeurons, numberOfPreviousNeurons + 1];

            switch (memoryMode)
            {
                case MemoryMode.GET:
                    tmpWeightsString = File.ReadAllLines(path);
                    string[] memoryElement;
                    for (int i = 0; i < numberOfNeurons; i++)
                    {
                        memoryElement = tmpWeightsString[i].Split(separator);
                        for (int j = 0; j < numberOfPreviousNeurons + 1; j++)
                        {
                            weights[i, j] = double.Parse(memoryElement[j].Replace(',', '.'),
                                System.Globalization.CultureInfo.InvariantCulture);
                        }
                    }
                    break;

                    //case MemoryMode.SET:
            }
            return weights;
        }
    }
}
