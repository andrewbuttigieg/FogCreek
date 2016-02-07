using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fogcreek
{
    public class Program
    {
        static int ContainsPair(string haystack){
            //var masterCheck = new Dictionary<char, bool>();
            int head = 0;
            foreach (var needle in haystack){
                var pos = haystack.IndexOf(needle, ++head);
                if (pos >= 0)
                    return pos;
            }
            return -1;
        }
        
        static Tuple<int, int> FindLongest(string haystack){
            int head = 0;
            int tail = 0;
            int needle = 0;
            int longest = 0;
            do {
                if (haystack.Length > head && haystack.IndexOf(haystack[head], head + 1) > -1){
                    //optimisation, we know where to start the check
                    for(int i = haystack.IndexOf(haystack[head], head + 1); i < haystack.Length; i++){
                        if (haystack[head] == haystack[i]){
                            //see if this is the longest
                            if (i - head > longest){
                                var pos = ContainsPair(haystack.Substring(head + 1, (i - head) - 1));
                                if (pos < 0)
                                {
                                    //this is the longest pair we know of without a pair in it
                                    longest = i - head;
                                    needle = head;
                                    tail = i;
                                }
                                else{
                                    //we break here because we know that we have pairs in the substring so there is no way we have the longest pair here
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            while (head++ <= haystack.Length);
            return new Tuple<int, int>(needle, tail);
        }
        
        private static StringBuilder MoveToBack(StringBuilder test, Tuple<int, int> location){
            var charToMoveToBack = test[location.Item1];
            test = test.Remove(location.Item1, 1);
            test = test.Remove(location.Item2 - 1, 1);
            test = test.Append(charToMoveToBack.ToString());
            return test;
        }
        
        private static string TrimAfterUnderscore(string haystack){
            if (haystack.IndexOf("_") > 0)
                return haystack.Substring(0, haystack.IndexOf("_"));
            else 
                return haystack;
        }
        
        public static void Main(string[] args)
        {
            //var test = new StringBuilder("ttvmswxjzdgzqxotby_lslonwqaipchgqdo_yz_fqdagixyrobdjtnl_jqzpptzfcdcjjcpjjnnvopmh");
            var test =toDecrypt.Replace("\n", "");
            //Console.WriteLine("Text to decode: " + test);
            int i = 0;
            do{
                var positionStartLongest = FindLongest(test.ToString());
                 //Console.WriteLine(positionStartLongest);
                if (positionStartLongest.Item1 == 0 && positionStartLongest.Item2==0)
                    break;
                else
                    test = MoveToBack(test, positionStartLongest);
                Console.WriteLine(i++);
            } while(true);
            Console.WriteLine("Final decoded text is: " + TrimAfterUnderscore(test.ToString()));
            
        }
        
        static StringBuilder toDecrypt = new StringBuilder(@"hpevfwqjmjryhemuqjoiatpjmddxdjwzskdcfgdtbmkbcxrnmjuoyddnqwluimjwvguxehszxzvbmufq
lrepncxxbrrzxnzmkoyhrjcstvfazyhrhgssximjdfcmdjusylfkwbedyrsxovrmvjzaljfjmywpfnjg
isoqbdyspgzlcmdjmhbpxhzvvhckidzuwzkauffsujmcrhvgeqvasjakgtzlxkthjqwxypmsovjbfshr
rxtdvkmbyhejoeydnrdowuwhgmbvxmpixyttglsjgmcoqbberssfjraaqfrkmebsozsjfnubhktbbai_
vxbifbofyednnutmxtisvfsktbqfijfzdjoqybuohtztysqelaqyixyaiolbgwylwfisfwubivuoablx
smrqggedwyiqvseevwbcxcfjttdbweedcjgnsorizflsjtmltcoaynsrsupavqwcyzhgiplwkohlhrai
nazaacvuqblpbzimgoxirejbshnbmdtgsbvlhpnugggencjaczqqiwixrwiyobmlkbwdlwcioqmjhoac
dvcqdypxeichmgywocbcafumthdqrbjnpgnnmaasxiaxxfymcyiuqduztqneodstbcnjpeebgxgosoyd
vpzlqjuroebbehafsemanwprhwkircuhlgcftqsjdusrqetbthxclfokpdlspxzuvhxpbeqqbfpqffsg
yilqltfxrmtimcugytazkerhcfnirtavcnmfdyictlncwttkmxyfhgejygfefqrjknuqsfldmjmwjdfq
sicfrzbfazchdgznekwmhridelcejnkmcgmpgtihbwmplrtrrefoyhyzxpjjlkabbbgspeokzhpjxsvp
fjmdsoripvfrgyzxodoeirwwdaofdmwqrqyvdijlfqyzfspdoyrhewxbpufdqcpqdolkmrnvedixzpfd
akggkslxcrjbrmnynviihbkzaqqffkkcgwjbettexhlwlasdfjnslwsmnclhafvebxxfdozsjtdvobik
rrsuysujwliobagobxmlyxjeltwzwxpyrnkdxfemotfncyriaycyfemygjmpboocgtsvttqntegvleyn
wgpjhyyysbltoxljsascsngbgfqmpzgpejzlmdkjzzlfxvagyrasmpzqntgqsvyqjugkhbrbkiqewlyf
tvsq_______znp_____xkwt______wef______tz______kfc_______ha_______pn__lmg__iakrbt
iyfi__uojrxvx__tps__fp__pfpndbi__ggpalde__wmd__kn__ifiadob__hdljdbd__zl__whlwilt
bcmt__haagmjg__dwx__oh__utnzudq__xstxxyc__vly__mr__viilzav__swosyvc__i__hnaqxyev
jykc__wyfoyir__ewp__ij__mrdavxl__tcdtxqy__fnr__cf__mrkepwj__djhrsau____lhefqxgmu
zdgf______tjg__fip__mi__b____xc__vjvhpqy______vff_____wuup_____kqct___htiggvvpet
yvco__pqbrlox__ayj__af__dnn__kx__mlitytx____jauna__kncmiym__dlwushk____gjptzccgc
nntt__hfqyxzi__eqn__vz__hlh__we__dtfkfvf__g__litm__zeqjtdl__bkdapxs__o__oxeouwer
bfjr__ipcqmop__kec__ip__icc__ci__vpxxueu__eq__sau__nhheydy__efqkdgq__us__pzlndhk
hdmk__cmfvzwcb_____xdka______trj______yj__xpi__he_______nb_______by__rrn__tvxvig
jfpseyjjbrrtsfnmbrokdqtfzhhdtbhtvpiyshmvcqaypfxcvbgvbvwrkanjfcsjnanmktkwimnvynuk
cmgtqmovkrdmfuduqvbqydagsttictcnsrhfrpoebcehdzhjamykqpjtktufcvokljjijjsrivyhxtgw
ojgoujyhmekzsoczwlqnruwcuhudgfaijzrkewzgjvorsmabpcdmurctwjrddcnkmfvabjwlbqssihdy
bgfqchqdvjcsdllrlwmyikuvthguzfbgocaeqktvbcapzdcfjphqnhundtljqjeyfrkjspfvghqddxwx
idtjjkctrkfcjmdpqyvavqbntpmkkuswfgbgalrysjfnzezjjscahoodjjelavydefzjmhsqfufsexlv
vzziymsyqrcvhsrxjnysioswvjlqdbnwgyjlanmhzkbygkptycdoifsibytbrixggjeiepaybzxhvfsy
ayeptgpxbhhfkkpromhjykfxnujorlzcmkcmvvgmveyfkgiwgosznfpmbhixsakxfkuxhwcgularehpa
guquulrjllxmkfzgnchrxzcfdklytpfnezergkwkhgalqlvdhkdgulgfaxtybqttcjtlgmfwaymaxlwa
spyrboibwkzzbtgigyswbtpwxgphcmkfpmvbfjimnxctinqssshofhlvlpqcwiuacjyxyqmvaibezofv
atyhpqvjubgcwqeoytloypjphoxeimumuvswxkgamodoxiciwmgxvsenkgdhttzlenjbszrksopicjcj
nvsosrapkfilwsaoptdavlfglioqpwoqskbgikksnnuzvmxyrtrbjouvgokxgbnwxnivtykvhjkaydsk
zoowbhjrlojgeecdoggqqtomcdgrjzmlkhubyaewwtrlyutsptdrrigopueicoganyasrjeaiivzairu
lklovyrpckwpowprxtvhaeivpudfchxbwvtosmivpcsesbzpsynxitlisuifuehceonjeydljzuzpsgj
llcywoxbblitscquxiykcjxhsgkbhfhfrshsrpyrcaetahuwbeybvlvkthxydkapxlfikdwudjkmjjsa
zajxpuikiqwsifhldfovqoycwmtlmcaycirhcehxnpfadrgyaogpcmomcgtmacnvbwfnimaqqvxijcbp
mckwimloiinindfuakqjmpyjisxnbybtywhymnkdoyiphijzelmrazplgfcmcsjiovxqdxmuqulzklgx");
    }
}
