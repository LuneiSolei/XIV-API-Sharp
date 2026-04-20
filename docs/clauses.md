# Clauses

> [!NOTE]
> Our implementation of clauses differs slightly from the official XIV API 
> documentation. 
> 
> This is due to the fact that using the official syntax verbatim may 
> result in some undesired behavior such as returning results that don't 
> quite match what was queried.

## Base Clause

<hr/>

Clauses are blocks of text inside QueryStrings which apply various rules when 
comparing a specifier against a value. In their most basic form, a clause 
consists of the following: ``[specifier][operator][value]``


1) **Specifier:** The name of the field to compare the value to.
2) **Operator:** The type of comparison to perform.
3) **Value:** The value of the field.

> Example:
> > Foo="Bar"

In the above example:

* Specifier = 'Foo'
* Operator = '='
* Value = "Bar" (quotations included)

## Specifiers

<hr/>

Specifiers determine which field to apply the comparison operator to. They 
also have their own small set of syntax and rules.

> [!IMPORTANT]
> Specifiers are CASE SENSITIVE! Use PascalCase. 
> > "Name" != "name"

<br/>

Dot notation can be used to specify fields nested inside structs and other 
relationships:

``ClassJob.Abbreviation="BLM"``

Similarly, array access notation can be used to specify elements in an array:

``BaseParam[].Name="Spell Speed"``

Lastly, languages may be specified, individually per clause, via an "@" 
decorator:

``Name@ja="天使の筆"``

## Operators

<hr/>

Clauses support multiple comparison operations.

| Operation                    | Applicable Type | Example                                                                                                         | Description                                       |
|------------------------------|-----------------|-----------------------------------------------------------------------------------------------------------------|---------------------------------------------------|
| ``=``                        | any             | ``Name="Curtana"`` <br/><br/>Only matches "Name" fields that are exactly "Curtana".                             | Matches on exact value.                           |
| ``>=``, ``>``, ``<=``, ``<`` | number          | ``Amount<=243.03``                                                                                              | Matches on mathematical statements that are true. |
| ``~``                        | string          | ``Name~"Phantom"`` <br/><br/>Matches "Name" fields that contain the word "Phantom" anywhere inside their value. | Matches on partial string values.                 |

## Multiple Clauses & Decorators

<hr/>

Decorators are extra syntax that modify the behavior of a clause. An earlier 
example showcased this via the "@" decorator. Pluses (+) and minuses (-) can 
also be used as decorators by placing them *in front* of the clause.

* **Plus(+):** Result(s) __MUST__ match this clause in order to be returned.
* **Minus(-):** Result(s) __MUST NOT__ match this clause in order to be 
  returned. In other words, result(s) that *do* match are thrown out.

> Examples:
> > ``+Name="Runaway Rod"``
> 
> > ``-Name~"Materia XI"``

> [!WARNING]
> The second example would reject any "Materia XI" matches, but it would also 
> reject any "Materia XII" matches as well!

> [!TODO]
> Add link to QueryString documentation.

Multiple clauses may be specified in a single QueryString. Official XIV API 
documentation states that these must be separated by literal whitespace. 
However, testing has revealed that this can cause some unexpected results to 
be returned. Instead, multiple clauses should be separated via literal plus 
signs (+).

As a result of this, clause decorators should be URI encoded instead of 
being literal. For example a "+" decorator should be "%2B".