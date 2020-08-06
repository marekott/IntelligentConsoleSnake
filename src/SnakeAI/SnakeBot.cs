using System;
using System.Collections.Generic;
using System.Linq;
using SnakeAI.Models;
using SnakeGame;
using SnakeGame.Interfaces;

namespace SnakeAI
{
    public class SnakeBot : ISnakeBot
    {
        private readonly SnakeAIModel _snakeAIModel;
        private readonly ModelInputHelper _modelInputHelper;

        public SnakeBot(SnakeAIModel snakeAIModel, ModelInputHelper modelInputHelper)
        {
            _snakeAIModel = snakeAIModel;
            _modelInputHelper = modelInputHelper;
        }

        public DirectionOfMove ChooseDirection(IntelligentSnake snake, Reward reward, Map map)
        {
            var predictedResults = _snakeAIModel.MakePredictions(PrepareInputData(snake, map));

            var direction = predictedResults.Where(p => !p.Prediction)
                                .OrderBy(p => p.Probability).ToList();

            return direction.Any() ? (DirectionOfMove) direction.First().SuggestedDirection : DirectionOfMove.Right;
        }

        private IEnumerable<SnakeData> PrepareInputData(IntelligentSnake snake, Map map)
        {
            IEnumerable<SnakeData> data = new[]
            {
                new SnakeData
                {
                    SuggestedDirection = 0,
                    ObstacleUp = Convert.ToSingle(_modelInputHelper.ObstacleUp(snake, map) || snake.ObstacleUp()),
                    ObstacleRight = Convert.ToSingle(_modelInputHelper.ObstacleRight(snake, map) || snake.ObstacleRight()),
                    ObstacleDown = Convert.ToSingle(_modelInputHelper.ObstacleDown(snake, map) || snake.ObstacleDown()),
                    ObstacleLeft = Convert.ToSingle(_modelInputHelper.ObstacleLeft(snake, map) || snake.ObstacleLeft())
                },
                new SnakeData
                {
                    SuggestedDirection = 1,
                    ObstacleUp = Convert.ToSingle(_modelInputHelper.ObstacleUp(snake, map) || snake.ObstacleUp()),
                    ObstacleRight = Convert.ToSingle(_modelInputHelper.ObstacleRight(snake, map) || snake.ObstacleRight()),
                    ObstacleDown = Convert.ToSingle(_modelInputHelper.ObstacleDown(snake, map) || snake.ObstacleDown()),
                    ObstacleLeft = Convert.ToSingle(_modelInputHelper.ObstacleLeft(snake, map) || snake.ObstacleLeft())
                },
                new SnakeData
                {
                    SuggestedDirection = 2,
                    ObstacleUp = Convert.ToSingle(_modelInputHelper.ObstacleUp(snake, map) || snake.ObstacleUp()),
                    ObstacleRight = Convert.ToSingle(_modelInputHelper.ObstacleRight(snake, map) || snake.ObstacleRight()),
                    ObstacleDown = Convert.ToSingle(_modelInputHelper.ObstacleDown(snake, map) || snake.ObstacleDown()),
                    ObstacleLeft = Convert.ToSingle(_modelInputHelper.ObstacleLeft(snake, map) || snake.ObstacleLeft())
                },
                new SnakeData
                {
                    SuggestedDirection = 3,
                    ObstacleUp = Convert.ToSingle(_modelInputHelper.ObstacleUp(snake, map) || snake.ObstacleUp()),
                    ObstacleRight = Convert.ToSingle(_modelInputHelper.ObstacleRight(snake, map) || snake.ObstacleRight()),
                    ObstacleDown = Convert.ToSingle(_modelInputHelper.ObstacleDown(snake, map) || snake.ObstacleDown()),
                    ObstacleLeft = Convert.ToSingle(_modelInputHelper.ObstacleLeft(snake, map) || snake.ObstacleLeft())
                }
            };

            return data;
        }
    }
}
