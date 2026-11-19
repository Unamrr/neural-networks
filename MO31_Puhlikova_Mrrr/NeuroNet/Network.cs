namespace MO31_Puhlikova_Mrrr.NeuroNet
{
    class Network
    {
        private InputLayer input_layer = null;
        private HiddenLayer hidden_layer1 = new HiddenLayer(71, 15, NeuronType.Hidden, nameof(hidden_layer1));
        private HiddenLayer hidden_layer2 = new HiddenLayer(33, 71, NeuronType.Hidden, nameof(hidden_layer2));

        private OutputLayer output_layer = new OutputLayer(10, 33, NeuronType.Output, nameof(output_layer));

        private double[] fact = new double[10];//массив фактического выхода сети
        private double[] e_error_avr; //среднеее значение энергии  ошибки эпохи обучения 
        //свойства

        public double[] Fact { get => fact; }// массив фактического выхода сети
        //среднеее значение энергии  ошибки эпохи обучени
        public double[] E_error_avr { get => e_error_avr; set => e_error_avr = value; }
        //конструктор
        public Network() {}
        //прямой проход сети
        public void ForwardPass(double[] netInput)
        {
            hidden_layer1.Data = netInput;
            hidden_layer1.Recognize(null, hidden_layer2);
            hidden_layer2.Recognize(null, output_layer);
            output_layer.Recognize(this, null);

        }

    }
}
