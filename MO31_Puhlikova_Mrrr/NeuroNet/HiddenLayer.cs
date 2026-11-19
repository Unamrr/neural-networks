namespace MO31_Puhlikova_Mrrr.NeuroNet
{
    class HiddenLayer : Layer
    {
        public HiddenLayer(int non, int nopn, NeuronType nt, string type) : base(non, nopn, nt, type)
        {
        }

        //прямой проход
        public override void Recognize(Network net, Layer nextLayer)
        {
            double[] hidden_out = new double[numofneurons];
            for (int i = 0; i < numofneurons; i++)
                hidden_out[i] = neurons[i].Output;

            nextLayer.Data = hidden_out;//передача входного сигнала на вход следующего слоя
        }

        //обартный проход ЗАГЛУШКА - ДОПИСАТЬ ПОЗЖЕЕ!!!!!!!
        public override double[] BackwardPass(double[] gr_sums)
        {
            

            double[] gr_sum = new double[numofprevneurons];
            //вычисление градиентных сумм выходного слоя
            for (int j = 0; j < numofprevneurons; j++)
            {
                double sum = 0;
                for (int k = 0; k < numofneurons; k++)
                    sum += neurons[k].Weights[j + 1] * neurons[k].Derivative * gr_sum[k];//

                gr_sum[j] = sum;
            }

            for (int i = 0; i < numofneurons; i++) //цикл коррекции синаптическиъ весов
                for (int n = 0; n < numofprevneurons + 1; n++)
                {
                    double deltaw;
                    if (n == 0) //если порог
                        deltaw = momentum * lastdeltaweights[i, 0] + learningrate * neurons[i].Derivative * gr_sum[i];
                    else
                        deltaw = momentum * lastdeltaweights[i, n] + learningrate * neurons[i].Inputs[n - 1] * neurons[i].Derivative * gr_sum[i];

                    lastdeltaweights[i, n] = deltaw;
                    neurons[i].Weights[n] += deltaw;//коррекция весов 
                }


            return gr_sum;
        }
    }
}
