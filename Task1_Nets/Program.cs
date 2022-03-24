

using System.Text;

Console.OutputEncoding = Encoding.UTF8;

var mega = Math.Pow(10, 6);
var boltzmann = 1.38 * Math.Pow(10, -23);

var W = 95 * mega;
const int S_t = 0;
const int N_t = -105;
const int L_r = 1;
const int L = 135;
const int T_t = 22;
const int T_r = 55;

const int EbN0 = 11;
const double spec_eff = 0.4;

var Tk = 10 * Math.Log10(boltzmann * (273 + T_r));
var Tt = 10 * Math.Log10(boltzmann * (273 + T_t));
var SN0 = S_t - L - Tk - L_r - Tt / L - N_t / L;
Console.WriteLine($"Бюджет мощности : {Math.Round(SN0, 1)} W");

var rb = SN0 - EbN0;
var r_power = Math.Pow(10, rb/10);
var r_line = W * spec_eff;
var SN0_wd = Math.Pow(10, SN0/10);
var nu = Math.Log2(1/W * SN0_wd + 1);
var r_pred = nu * W;

Console.WriteLine("==============================");
Console.WriteLine($"Максимальная скорость: {Math.Round(r_line / mega, 1)} Mb");
if(r_power * spec_eff > W){
    Console.WriteLine("Следовательно, система ограничена полосой");
}

Console.WriteLine($"Предельная эффективность: {Math.Round(nu, 1)} bit/sec * hz^-1");
Console.WriteLine($"Предельная скорость: {Math.Round(r_pred / mega, 1)} Mb");
