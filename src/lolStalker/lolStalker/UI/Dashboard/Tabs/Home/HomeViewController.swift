//
//  HomeViewController.swift
//  lolStalker
//
//  Created by Muhand Jumah on 6/6/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import Foundation
import UIKit

class HomeViewController: UIViewController {
    ////////////////////////////////////
    //            Controls
    ////////////////////////////////////
    let notPlayingLabel: UILabel = {
        let label = UILabel()
        label.text = "You are not\nplaying any game\nat this time"
        label.textColor = UIColor(hex: "#95989A")
        label.font = UIFont.italicSystemFont(ofSize: Helper.getFontOf(xdFont: 20, referenceHeight: nil, referenceWidth: nil))
        label.numberOfLines = 0
        label.textAlignment = .center
        return label
    }()
    
    let gameView: GameView = {
        let view = GameView()
        
        var player: Player = Player()
        player.summonerName = "WarDesigner"
        player.championName = "Aatrox"
        player.backgroundImage = #imageLiteral(resourceName: "tempChampion")
        player.profileImage = #imageLiteral(resourceName: "tempProfile")
        player.spell1 = #imageLiteral(resourceName: "tempSpell1")
        player.spell2 = #imageLiteral(resourceName: "tempSpell2")
        
        var team: Team
        
        do {
            team = try Team(players: player, player, player, player, player)
            view.game = Game(team1: team, team2: team)
        } catch {
            print(error)
        }
        
        
        
        return view
    }()
    
//    let cancelBtn: UIButton = {
//        let button = UIButton()
//        button.setBackgroundColor(color: UIColor(hex: "#010A13")!, forState: .normal)
//        button.setBackgroundColor(color: UIColor(hex: "#CE9340")!, forState: .highlighted)
//        button.setTitleColor(UIColor(hex: "#CE9340"), for: .normal)
//        button.setTitleColor(UIColor(hex: "#010A13"), for: .highlighted)
//        button.setTitle("CANCEL", for: .normal)
//        button.layer.borderWidth = Helper.getWidthOf(xdWidth: 1, referenceWidth: nil, originalWidth: nil)
//        button.layer.borderColor = UIColor(hex: "#CE9340")?.cgColor
//        button.titleLabel?.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 12, referenceHeight: nil, referenceWidth: nil))
//        button.addTarget(self, action: #selector(cancelPressed), for: .touchUpInside)
//        return button
//    }()
    
    ////////// END OF CONTROLS /////////
    override func viewDidLoad() {
        super.viewDidLoad()
        setupView()
        setupSubViews()
        setupConstraints()
        setupMargins()
    }
    
    func setupView() {
        view.backgroundColor = UIColor(hex: "#010A13")
        hideKeyboardWhenTappedAround()
    }
    
    func setupSubViews() {
//        view.addSubview(notPlayingLabel)
        view.addSubview(gameView)
//        view.addSubview(cancelBtn)

//        notPlayingLabel.translatesAutoresizingMaskIntoConstraints = false
        gameView.translatesAutoresizingMaskIntoConstraints = false
        
        gameView.delegate = self
    }
    
    func setupConstraints() {
        notPlayingLabel.translatesAutoresizingMaskIntoConstraints = false
        gameView.translatesAutoresizingMaskIntoConstraints = false
//        cancelBtn.translatesAutoresizingMaskIntoConstraints = false
        
//        if #available(iOS 11, *) {
//            let guide = view.safeAreaLayoutGuide
////            notPlayingLabel.centerXAnchor.constraint(equalTo: guide.centerXAnchor).isActive = true
////            notPlayingLabel.centerYAnchor.constraint(lessThanOrEqualTo: guide.centerYAnchor).isActive = true
//
//            gameView.centerXAnchor.constraint(equalTo: guide.centerXAnchor).isActive = true
//            gameView.centerYAnchor.constraint(equalTo: guide.centerYAnchor).isActive = true
//            gameView.heightAnchor.constraint(equalTo: guide.heightAnchor).isActive = true
//            gameView.widthAnchor.constraint(equalTo: guide.widthAnchor).isActive = true
//        } else {
////            notPlayingLabel.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
////            notPlayingLabel.centerYAnchor.constraint(lessThanOrEqualTo: view.centerYAnchor).isActive = true
//
            gameView.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
//        gameView.topAnchor.constraint(equalTo: view.topAnchor)
            gameView.bottomAnchor.constraint(equalTo: view.bottomAnchor).isActive = true
            gameView.heightAnchor.constraint(equalTo: view.heightAnchor, constant: -UIApplication.shared.statusBarFrame.height).isActive = true
            gameView.widthAnchor.constraint(equalTo: view.widthAnchor).isActive = true
//        }
    }
    
    func setupMargins() {
    }
    
    override func viewWillTransition(to size: CGSize, with coordinator: UIViewControllerTransitionCoordinator) {
        super.viewWillTransition(to: size, with: coordinator)
        view.setNeedsDisplay()
    }
}

extension HomeViewController: GameViewDelegate {
    func didSetGame(game: Game, form: GameView) {
        print("NEW GAME")
    }
}

//extension HomeViewController: TeamViewDelegate {
//    func didTapAPlayer(form: TeamTableView) {
//        print("TASFASDF")
//        let playerViewController = PlayerViewController()
////        playerViewController.modalPresentationStyle = UIModalPresentationStyle.fullScreen
//        self.present(playerViewController, animated: true, completion: nil)
//    }
//}
