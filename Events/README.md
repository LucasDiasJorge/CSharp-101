# Implementa��o do Padr�o Observer com Eventos em C#

## Introdu��o
Este projeto demonstra o uso do padr�o de projeto **Observer** utilizando **eventos e delegados** em C#. O padr�o Observer � amplamente utilizado para estabelecer uma comunica��o desacoplada entre objetos, onde um objeto (o *Publisher*) notifica automaticamente seus *Subscribers* quando ocorre uma mudan�a de estado.

## Conceitos Principais
### Padr�o Observer
O **Observer** � um padr�o de design comportamental que define uma depend�ncia de um para muitos entre objetos. Sempre que um objeto muda de estado, todos os objetos dependentes s�o notificados automaticamente.

No C#, a implementa��o deste padr�o pode ser feita utilizando eventos e delegados, que fornecem uma maneira integrada de gerenciar assinaturas e notifica��es de forma segura.

## Estrutura do Projeto
O projeto cont�m os seguintes componentes principais:

- **Publisher (Button)**: Define um evento `Clicked`, ao qual outros objetos podem se inscrever.
- **Subscriber (Logger)**: Escuta o evento `Clicked` e executa uma a��o quando notificado.
- **Program**: Cont�m o ponto de entrada da aplica��o e demonstra a funcionalidade do padr�o Observer.

## C�digo Explicado
### Classe Button (Publisher)
```csharp
public class Button
{
    public event EventHandler? Clicked;

    public void Click()
    {
        Console.WriteLine("[Button] Clicked!");
        Clicked?.Invoke(this, EventArgs.Empty);
    }
}
```
- Define um evento `Clicked` do tipo `EventHandler`.
- Quando o m�todo `Click()` � chamado, ele dispara o evento `Clicked`, notificando todos os assinantes.

### Classe Logger (Subscriber)
```csharp
public class Logger
{
    public void OnButtonClicked(object? sender, EventArgs e)
    {
        Console.WriteLine("[Logger] Button was clicked!");
    }
}
```
- Define o manipulador de eventos `OnButtonClicked`, que responde ao evento `Clicked` do `Button`.
- Exibe uma mensagem no console sempre que o evento � acionado.

### Classe Program (Execu��o do Programa)
```csharp
class Program
{
    static void Main()
    {
        var button = new Button();
        var logger = new Logger();

        button.Clicked += logger.OnButtonClicked; // Inscri��o no evento
        button.Click(); // Gera sa�da no console

        button.Clicked -= logger.OnButtonClicked; // Desinscri��o do evento
        button.Click();  // Nenhuma sa�da, pois n�o h� inscritos
    }
}
```
- Cria um objeto `Button` e um `Logger`.
- O `Logger` se inscreve no evento `Clicked` do `Button`.
- Quando `Click()` � chamado, `OnButtonClicked()` � acionado.
- Em seguida, o `Logger` � desinscrito do evento, e novos cliques n�o geram sa�da.

## Similaridade com o Padr�o Observer
Os eventos em C# seguem a mesma filosofia do padr�o Observer:
- O **Button** � o *Sujeito (Subject)* que mant�m uma lista de ouvintes (subscribers).
- O **Logger** � o *Observer*, que responde �s mudan�as (cliques no bot�o).
- A notifica��o ocorre automaticamente atrav�s do evento `Clicked`.
- Podemos adicionar ou remover observadores dinamicamente, tornando o sistema flex�vel e modular.

## Benef�cios
- **Desacoplamento**: O *Publisher* n�o precisa conhecer os detalhes dos *Subscribers*.
- **Flexibilidade**: Novos *Subscribers* podem ser adicionados sem modificar o c�digo do *Publisher*.
- **Manuten��o facilitada**: Segue o princ�pio **Open/Closed**, permitindo extens�es sem altera��es no c�digo existente.

## Conclus�o
Este projeto demonstra como os eventos e delegados do C# implementam eficientemente o padr�o Observer. Usar eventos � uma maneira idiom�tica e segura de implementar comunica��o ass�ncrona entre objetos em C#.

