  重构和复用是软件的一个古老话题。

  在日常的软件项目开发的过程序中，如何保证团队代码的强健，同时在不断变化的需过程中最大限度的保障代码的一致性，是项目开发中的难以控制的，我们可以借助各种源码管理和标准工作流程制度和增加各种岗位人手来进行控制，但随着时间的推移，由于各种水平的开发人员，加入各种藕合的非藕合的功能，代码变得难以管理。

  但市场和客户对我们的软件总是看起来让人不可理喻，当我们信心满满的把软件产品交付给我们客户时依然要应对各种指责，有的需求反复，“不，这完全没有达到我们当时的需求，和我想的不一样”，在不断的变化，不断的反复，代码被修改得面目全非，团队陷于无助之中。

  从实际的管理中，我们不能完全消除代码的藕合、代码的混乱，每一个程序员心中都有自己的江湖，所谓“文无第二、武无第一”，每个程序员都会认为自己的代码是没有任何问题的。作为项目的管理者，只能最大限度的降低程序人员的人为因素来的变化，让标准化的代码在项目占有越大的份量，如果这是标准代码是由工具产生，那么在需求发生变化时，重购代码也变得非常轻松且易控。

  如果在构建项目之初的与客户需求交流中，以工具来生成标准代码并因此为用户快速构建一个可见的Demo,那么项目需求就会变得更加明确、易控。尽管这与最终交付的产品还有很大的差距，但仍然可以减少客户需求的明确性。如果我们把可控代码与非控代码在生产时进行分离，那么当后期客户需求变化时，仍然可以让工具重构变化的需求。

  让技术优秀的人员构建基础库，变把日常开发中用的常用功能模板化，这样，框架-工具-模板，就会在团队中成为技术、经验的容器，让再开发变得更加容易、可控、稳定。我们不需要把大把的时化在那些重复且繁重的属性代码编写，并不断的进行各种属性的拷贝，在需求变更时，又化大量时间云矫正。我们应该让更多时间去与客户交流业务需求，编写强健的应用设计上，那么我们应该使用正确的框架、同时逐渐累积可复用的功能支持库，并使功能模块低耦合，使用代码工具将各种功能调用模板化，这样不仅保证了编码上的一至性，同时最大限度降低编码的劳动强度，减少重复简单代码所消耗宝贵的时间，也能使组织和团队在协调技术的一至上化更少的时间和金钱的投入。

  一个好的架构能应对不同的应用需求，但是没有一个可行的，万能的架构，不然我没在这里就不用讨论架构的问题了。这里不仅是代码的问题，随着时间的推移，各种编程技术的进步，让一些原本复杂的问题变得简单，功能更容易实现，而客户需求总是贪婪的，所要求的更加复杂，使得新的需求产生，技术实现同样的需要更多的精力和时间，就因为如此，我们不应该同时也没必要把时间和精力耗在无尽的重构中，而应该让编写代码更加工具化、模板化换个比较时尚的词，更加智能化。
