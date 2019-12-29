# Físicas en Unity

 -Autor: Gabriel Melián Hernández.

Descripción de la Práctica:
  Sobre la escena que has trabajado programa los scripts necesarios para las siguientes acciones:

-Cada vez que el objeto jugador colisione con una esfera se debe incrementar un contador. Una de las escenas estará fija, la otra debe estar rodando aleatoriamente por la escena.

-La esfera debe responder a la física. Se deben incluir cilindros que actúen como sensores, de forma que cambian de color cuando el objeto jugador o la esfera estén cerca. Se deben elegir tres tonos de intensidad que se asignarán según el estado de la colisión para cada uno de ellos. Por ejemplo, Ethan 3 tonos de rojo según entre en colisión, siga en colisión o salga de la colisión.

-Ubicar un tercer objeto que sea capaz de detectar colisiones y que se mueva con las teclas: I, L, J, M

----------------------------------


Gif de su funcionamiento: 
https://gyazo.com/2f4ce1a5a9c55c31a014e888dd040faf

https://gyazo.com/ce557c96f7ef64d6c3191dd4ca44f5ec

https://gyazo.com/70be571d04b167d67ee81ca8c181c3dc

Vamos a comentar como mediante los scripts podemos resolver el primer enunciado de la práctica:

        -Cada vez que el objeto jugador colisione con una esfera se debe incrementar un contador. Una de las escenas estará fija, la otra debe estar rodando aleatoriamente por la escena.
       
Creamos dos esferas en la escena, la primera deberá tener campo Static activado y no se moverá del sitio en el que la coloquemos, por otra parte crearemos una esfera a la que añadiremos el script MovAleatorio.cs, donde se implementarán los métodos necesarios para que la esfera se mueva aleatoriamente por el terreno.

        void RecalculateTargetPosition()
        {
          targetPosition = transform.position + Random.insideUnitSphere * wanderRadius;
          targetPosition.y = 0;
        }
        
En el método anterior recalculamos la posición de la esfera haciendo que su posición varíe dentro de un radio establecido y manteniendo su coordenada Y en 0 para que solo se mueva en los ejex XZ, este método será llamado en Update para su constante actualización.

        void Update()
        {
         towardsTarget = targetPosition - transform.position;
          if (towardsTarget.magnitude < 0.25f)
             RecalculateTargetPosition();

           Quaternion towardsTargetRotation  = Quaternion.LookRotation(towardsTarget, Vector3.up);
           transform.rotation = Quaternion.Lerp(transform.rotation, towardsTargetRotation, rotationSpeed * Time.deltaTime);
           transform.position += transform.forward * movementSpeed * Time.deltaTime;
       }
       
Una vez creados los dos objetos contra los que tenemos que colisionar crearemos a nuestro personaje controlabe (En este caso otra esfera) que se le dará física para comenzar a realizar la implementación del segundo apartado de la práctica, para ello añadiremos al objeto un Rigidbody y luego en el scripting se implementará un nuevo método de movimiento.

        public Rigidbody rb;
        
Para llevar a cabo el incremento del contador al chocar contra las dos esferas creadas anteriormente, primero debemos recoger sus referencias:

        EsferaMov = GameObject.FindGameObjectWithTag("Esfera Aleatoria");
        EsferaEst = GameObject.FindGameObjectWithTag("Esfera Estatica");
        
Una vez realizado esto simplemente crearemos un GUI para que se muestre por pantalla el "Score" que llevamos y mediante detección de colisiones contabilizamos el contador:

        private void OnCollisionEnter(Collision collision)
        {
         if (collision.gameObject.tag == "Esfera Aleatoria")
         {
              score += 10;
         }

          if (collision.gameObject.tag == "Esfera Estatica")
          {
              score += 10;
          }
        }

Por otra parte y una vez completado del paso 1 de la práctica vamos a añadirle movimeinto fisico a la esfera que tenía RigidBody:

        private void FixedUpdate()
        {
          if (Input.GetKey(KeyCode.W)) {
            rb.AddForce(Vector3.forward * 1f, ForceMode.Impulse);
            }
        }
De similar forma realizamos la implementacion para las demas teclas de WASD y así tendremos nuestro movimiento fisico en nuestra esfera con RigidBody y que además al tener activado el collider podrá reconocer colisiones algo que ya era necesario para la primera parte de la práctica y que será igual de necesario para la siguiente donde tendremos que crear varios cilindros que cuando la esfera choque con ellos cambien de color, teniendo 3 posibles estados y un color para cada uno de ellos dependiendo de si se encuentran en OnTriggerEnter, OnTriggerStay y OnTriggerExit.

Para ello en cada uno de los cilindros que creemos añadiremos un Script que tendrá el siguiente método:
        
        private void OnTriggerEnter(Collider other)
        {
          GetComponent<Renderer>().material.color = colors[0];
          Debug.Log("Verde");
        }

        private void OnTriggerStay(Collider other)
        {
          GetComponent<Renderer>().material.color = colors[1];
          Debug.Log("Rojo");
        }

        private void OnTriggerExit(Collider other)
        {
          GetComponent<Renderer>().material.color = colors[2];
          Debug.Log("Azul");
        }
        
Con estos métodos tenemos nuestros cilindros detectando colisiones y cambiando de color dependiendo de como esta se produzca, ya por último solo nos falta el último punto de la práctica:

        -Ubicar un tercer objeto que sea capaz de detectar colisiones y que se mueva con las teclas: I, L, J, M
        
Este objeto será otra esfera que se moverá sin fisica con las teclas IMLJ:
        
        if (Input.GetKey(KeyCode.I))
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

Y que tendrá un contador que irá incrementandose a medida que choque con cualquier otro objeto de la escena.

        private void OnCollisionEnter(Collision other)
        {
          colisiones += 1;
          Debug.Log("Numero de colisiones" + colisiones);
        }
